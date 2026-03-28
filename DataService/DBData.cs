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
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                add.AID = Guid.NewGuid();
                cmd.Parameters.AddWithValue("@Id", add.AID);
                cmd.Parameters.AddWithValue("@Name", add.Name);
                cmd.Parameters.AddWithValue("@Address", add.Address);
                cmd.Parameters.AddWithValue("@PNumber", add.PNumber);
                cmd.Parameters.AddWithValue("@Pcode", add.Pcode);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }



        public void InsertCard(Card card)
        {
            string query = @"INSERT INTO Card (Name, Card_Number, Expiration, cvv)
                                 VALUES (@Name, @CNumber, @EDate, @CVV)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Name", card.Name);
                cmd.Parameters.AddWithValue("@CNumber", card.CNumber);
                cmd.Parameters.AddWithValue("@EDate", card.EDate);
                cmd.Parameters.AddWithValue("@CVV", card.CVV);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }


        public void InsertBank(Bank bank)
        {
            string query = @"INSERT INTO Bank (HOLDER, Bank_Number, Bank_Name)
                                 VALUES (@Holder, @BNumber, @BName)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Holder", bank.Holder);
                cmd.Parameters.AddWithValue("@BNumber", bank.BNumber);
                cmd.Parameters.AddWithValue("@BName", bank.BName);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        public void InsertGcash(Gcash gcash)
        {
            string query = @"INSERT INTO Gcash (Name, Gcash_Number)
                                 VALUES (@Name, @GNumber)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Name", gcash.Name);
                cmd.Parameters.AddWithValue("@GNumber", gcash.GNumber);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
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
                    Name = "Ronelito T. Llaguno",
                    GNumber = "123456789"
                };
                InsertGcash(g);
            }
        }



        public List<ADD> GetAddresses()
        {
            string selectStatement = "SELECT ID, Name, Address, Phone_Number, Postal_Code FROM Address";

            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

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
            var card = new List<Card>();

            var selectStatement = "SELECT Name, Card_Number, Expiration, cvv FROM Card";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                card.Add(new Card
                {
                    Name = reader["Name"].ToString(),
                    CNumber = reader["Card_Number"].ToString(),
                    EDate = reader["Expiration"].ToString(),
                    CVV = reader["cvv"].ToString()
                });
            }

            sqlConnection.Close();
            return card;
        }

        public List<Bank> GetBanks()
        {
            var bank = new List<Bank>();

            var selectStatement = "SELECT HOLDER, Bank_Number, Bank_Name FROM Bank";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bank.Add(new Bank
                {
                    Holder = reader["HOLDER"].ToString(),
                    BNumber = reader["Bank_Name"].ToString(),
                    BName = reader["Bank_Name"].ToString()
                });
            }

            sqlConnection.Close();
            return bank;
        }

        public List<Gcash> GetGcash()
        {
            var gcash = new List<Gcash>();

            var selectStatement = "SELECT Name, Gcash_Number FROM Gcash";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                gcash.Add(new Gcash
                {
                    Name = reader["Name"].ToString(),
                    GNumber = reader["Gcash_Number"].ToString()
                });
            }

            sqlConnection.Close();
            return gcash;
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

            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);

            cmd.Parameters.AddWithValue("@Name", add.Name);
            cmd.Parameters.AddWithValue("@Address", add.Address);
            cmd.Parameters.AddWithValue("@PNumber", add.PNumber);
            cmd.Parameters.AddWithValue("@Pcode", add.Pcode);
            cmd.Parameters.AddWithValue("@Id", add.AID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpCard(Card card)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Card SET Name=@Name, Card_Number=@CNumber, Expiration=@EDate, cvv=@CVV WHERE ID=@Id";

            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);

            cmd.Parameters.AddWithValue("@Name", card.Name);
            cmd.Parameters.AddWithValue("@CNumber", card.CNumber);
            cmd.Parameters.AddWithValue("@EDate", card.EDate);
            cmd.Parameters.AddWithValue("@CVV", card.CVV);
            cmd.Parameters.AddWithValue("@Id", card.CID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpBank(Bank bank)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Bank SET HOLDER=@Holder, Bank_Number=@BNumber, Bank_Name=@BName WHERE ID=@Id";

            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);

            cmd.Parameters.AddWithValue("@Holder", bank.Holder);
            cmd.Parameters.AddWithValue("@BNumber", bank.BNumber);
            cmd.Parameters.AddWithValue("@BName", bank.BName);
            cmd.Parameters.AddWithValue("@Id", bank.BID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpGcash(Gcash gcash)
        {
            sqlConnection.Open();

            var updateStatement = @"UPDATE Gcash SET Name=@Name, Gcash_Number=@GNumber WHERE ID=@Id";

            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);

            cmd.Parameters.AddWithValue("@Name", gcash.Name);
            cmd.Parameters.AddWithValue("@GNumber", gcash.GNumber);
            cmd.Parameters.AddWithValue("@Id", gcash.GID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}