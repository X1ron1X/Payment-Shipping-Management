using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace DataService
{
    public class DBData : IData
    {
        private readonly string connectionString =
                @"Server=localhost\SQLEXPRESS;Database=dbpayship;Trusted_Connection=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public DBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();

        }


        public void InsertAddress(ADD add)
        {
            string query = @"INSERT INTO Address (ID, Name, Address, Phone_Number, Postal_Code)
                                 VALUES (@Id, @Name, @Address, @PNumber, @Pcode)";
            SqlCommand ins = new SqlCommand(query, sqlConnection);
            {
                add.AID = Guid.NewGuid();
                ins.Parameters.AddWithValue("@Id", add.AID);
                ins.Parameters.AddWithValue("@Name", add.Name);
                ins.Parameters.AddWithValue("@Address", add.Address);
                ins.Parameters.AddWithValue("@PNumber", add.PNumber);
                ins.Parameters.AddWithValue("@Pcode", add.Pcode);
                sqlConnection.Open();
                ins.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }



        public void InsertCard(Card card)
        {
            string query = @"INSERT INTO Card (ID, Name, Card_Number, Expiration, cvv)
                                 VALUES (@Id, @Name, @CNumber, @EDate, @CVV)";
            SqlCommand ins = new SqlCommand(query, sqlConnection);
            {
                card.CID = Guid.NewGuid();
                ins.Parameters.AddWithValue("@Id", card.CID);
                ins.Parameters.AddWithValue("@Name", card.Name);
                ins.Parameters.AddWithValue("@CNumber", card.CNumber);
                ins.Parameters.AddWithValue("@EDate", card.EDate);
                ins.Parameters.AddWithValue("@CVV", card.CVV);
                sqlConnection.Open();
                ins.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }


        public void InsertBank(Bank bank)
        {
            string query = @"INSERT INTO Bank (ID, HOLDER, Bank_Number, Bank_Name)
                                 VALUES (Id, @Holder, @BNumber, @BName)";
            SqlCommand ins = new SqlCommand(query, sqlConnection);
            {
                bank.BID = Guid.NewGuid();
                ins.Parameters.AddWithValue("@Id", bank.BID);
                ins.Parameters.AddWithValue("@Holder", bank.Holder);
                ins.Parameters.AddWithValue("@BNumber", bank.BNumber);
                ins.Parameters.AddWithValue("@BName", bank.BName);
                sqlConnection.Open();
                ins.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        public void InsertGcash(Gcash gcash)
        {
            string query = @"INSERT INTO Gcash (ID, Name, Gcash_Number)
                                 VALUES (@Id, @Name, @GNumber)";
            SqlCommand ins = new SqlCommand(query, sqlConnection);
            {
                gcash.GID = Guid.NewGuid();
                ins.Parameters.AddWithValue("@Id", gcash.GID);
                ins.Parameters.AddWithValue("@Name", gcash.Name);
                ins.Parameters.AddWithValue("@GNumber", gcash.GNumber);
                sqlConnection.Open();
                ins.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }


        public void AddSeeds()
        {
            var exAdd = GetAddresses();
            if (exAdd.Count == 0)
            {
                ADD a = new ADD
                {
                    AID = Guid.NewGuid(),
                    Name = "Ronelito T. Llaguno",
                    Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon",
                    PNumber = "09914687722",
                    Pcode = "4024"
                };
                InsertAddress(a);
            }

            var exCard = GetCards();
            if (exCard.Count == 0)
            {
                Card c = new Card
                {
                    CID = Guid.NewGuid(),
                    Name = "Ronelito T. Llaguno",
                    CNumber = "123456789",
                    EDate = "2030",
                    CVV = "1234"
                };
                InsertCard(c);
            }

            var exBank = GetBanks();
            if (exBank.Count == 0)
            {
                Bank b = new Bank
                {
                    BID = Guid.NewGuid(),
                    Holder = "Ronelito T. Llaguno",
                    BNumber = "123456789",
                    BName = "BDO"
                };
                InsertBank(b);
            }

            var exGcash = GetGcash();
            if (exGcash.Count == 0)
            {
                Gcash g = new Gcash
                {
                    GID = Guid.NewGuid(),
                    Name = "Ronelito T. Llaguno",
                    GNumber = "123456789"
                };
                InsertGcash(g);
            }
        }



        public List<ADD> GetAddresses()
        {
            string selectStatement = "SELECT ID, Name, Address, Phone_Number, Postal_Code FROM Address";

            SqlCommand get
                = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = get.ExecuteReader();

            var list = new List<ADD>();

            while (reader.Read())
            {
                ADD add = new ADD();

                add.AID = Guid.Parse(reader["ID"].ToString());
                add.Name = reader["Name"].ToString();
                add.Address = reader["Address"].ToString();
                add.PNumber = reader["Phone_Number"].ToString();
                add.Pcode = reader["Postal_Code"].ToString();

                list.Add(add);
            }

            sqlConnection.Close();
            return list;
        }

        public List<Card> GetCards()
        {
            var list = new List<Card>();

            var selectStatement = "SELECT ID, Name, Card_Number, Expiration, cvv FROM Card";
            SqlCommand get
                = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = get.ExecuteReader();

            while (reader.Read())
            {
                Card card = new Card();

                card.CID = Guid.Parse(reader["ID"].ToString());
                card.Name = reader["Name"].ToString();
                card.CNumber = reader["Card_Number"].ToString();
                card.EDate = reader["Expiration"].ToString();
                card.CVV = reader["cvv"].ToString();
                
            }

            sqlConnection.Close();
            return list;
        }

        public List<Bank> GetBanks()
        {
            var list = new List<Bank>();

            var selectStatement = "SELECT ID, HOLDER, Bank_Number, Bank_Name FROM Bank";
            SqlCommand get = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = get.ExecuteReader();

            while (reader.Read())
            {
                Bank bank = new Bank();

                bank.BID = Guid.Parse(reader["ID"].ToString());
                bank.Holder = reader["HOLDER"].ToString();
                bank.BNumber = reader["Bank_Name"].ToString();
                bank.BName = reader["Bank_Name"].ToString();
                
            }

            sqlConnection.Close();
            return list;
        }

        public List<Gcash> GetGcash()
        {
            var list = new List<Gcash>();

            var selectStatement = "SELECT ID, Name, Gcash_Number FROM Gcash";
            SqlCommand get = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = get.ExecuteReader();

            while (reader.Read())
            {
                Gcash gcash = new Gcash();

                gcash.GID = Guid.Parse(reader["ID"].ToString());
                gcash.Name = reader["Name"].ToString();
                gcash.GNumber = reader["Gcash_Number"].ToString();
             
            }

            sqlConnection.Close();
            return list;
        }

        public ADD? GetByaid(Guid id)
        {
            return GetAddresses().FirstOrDefault(t => t.AID == id);
        }

        public Card? GetBycid(Guid id)
        {
            return GetCards().FirstOrDefault(t => t.CID == id);
        }

        public Bank? GetBybid(Guid id)
        {
            return GetBanks().FirstOrDefault(t => t.BID == id);
        }

        public Gcash? GetBygid(Guid id)
        {
            return GetGcash().FirstOrDefault(t => t.GID == id);
        }

        public void UpAdd(ADD add)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Address SET Name=@Name, Address=@Address, Phone_Number=@PNumber, Postal_Code=@Pcode WHERE ID=@Id";

            SqlCommand up = new SqlCommand(updateStatement, sqlConnection);

            up.Parameters.AddWithValue("@Name", add.Name);
            up.Parameters.AddWithValue("@Address", add.Address);
            up.Parameters.AddWithValue("@PNumber", add.PNumber);
            up.Parameters.AddWithValue("@Pcode", add.Pcode);
            up.Parameters.AddWithValue("@Id", add.AID);

            up.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpCard(Card card)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Card SET Name=@Name, Card_Number=@CNumber, Expiration=@EDate, cvv=@CVV WHERE ID=@Id";

            SqlCommand up = new SqlCommand(updateStatement, sqlConnection);

            up.Parameters.AddWithValue("@Name", card.Name);
            up.Parameters.AddWithValue("@CNumber", card.CNumber);
            up.Parameters.AddWithValue("@EDate", card.EDate);
            up.Parameters.AddWithValue("@CVV", card.CVV);
            up.Parameters.AddWithValue("@Id", card.CID);

            up.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpBank(Bank bank)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Bank SET HOLDER=@Holder, Bank_Number=@BNumber, Bank_Name=@BName WHERE ID=@Id";

            SqlCommand up = new SqlCommand(updateStatement, sqlConnection);

            up.Parameters.AddWithValue("@Holder", bank.Holder);
            up.Parameters.AddWithValue("@BNumber", bank.BNumber);
            up.Parameters.AddWithValue("@BName", bank.BName);
            up.Parameters.AddWithValue("@Id", bank.BID);

            up.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpGcash(Gcash gcash)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Gcash SET Name=@Name, Gcash_Number=@GNumber WHERE ID=@Id";

            SqlCommand up = new SqlCommand(updateStatement, sqlConnection);

            up.Parameters.AddWithValue("@Name", gcash.Name);
            up.Parameters.AddWithValue("@GNumber", gcash.GNumber);
            up.Parameters.AddWithValue("@Id", gcash.GID);

            up.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}