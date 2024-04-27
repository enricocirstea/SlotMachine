/*
 * Init()
 * CloseConnection()
 * InsertUser()
 * SelectAll()
 * AuthenticateUser()
 * UpdateBalance()
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Database {
    public class Database {
        private SQLiteConnection conn = null;
       

        public Database() {
          
        }

        public void Init() {
            if (!File.Exists("Database.sqlite"))
                SQLiteConnection.CreateFile("Database.sqlite");

            try {
                conn = new SQLiteConnection("Data Source = Database.sqlite; Version = 3");
                conn.Open();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString()); ;
                return;
            }

            CreateTable();
            CreateWinnersTable();
        }

        public void CloseConnection() {
            if (conn != null) {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            else {
                Trace.WriteLine("There is no connection with database to close");
            }
        }

        private void CreateTable() {
            string stmt = "CREATE TABLE IF NOT EXISTS Users(ID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT UNIQUE, Password TEXT, Balance REAL)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        private string CreateHash(string text) {
            byte[] input = System.Text.Encoding.UTF8.GetBytes(text);
            HashAlgorithm cryptoProvider = new SHA256CryptoServiceProvider();

            byte[] hashValue = cryptoProvider.ComputeHash(input);

            return System.Text.Encoding.UTF8.GetString(hashValue);
        }

        public void InsertUser(string username, string password) {
            string HashedPassword = CreateHash(password);

            string stmt = "INSERT INTO Users(Username, Password, Balance) VALUES('" + username + "','" + HashedPassword + "', 0.0)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        public string SelectAll() {
            string stmt = "SELECT * FROM Users";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }

            string data = "";

            if (reader != null) {
                for (int i = 0; i < reader.FieldCount; ++i) {
                    data += reader.GetName(i) + "  ";
                }

                data += "\n";

                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString() + " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetString(2) + " ";
                    data += "\n";
                }
                reader.Close();

                return data;
            }

            return null;
        }

        public bool AuthenticateUser(string username, string password) {
            string HashedPassword = CreateHash(password);
            string stmt = "SELECT * FROM Users WHERE Username='" + username + "' AND Password='" + HashedPassword + "'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }

            string data = "not found";

            if (reader != null) {
                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString() + " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetString(2) + " ";
                    data += reader.GetDouble(3) + " ";
                    data += "\n";
                }
                reader.Close();
            }

            if (data != "not found")
                return true;
            else
                return false;
        }

        public void UpdateBalance(string username, double new_balance) { 

            string stmt = "UPDATE Users " +
                        "SET Balance=" + new_balance +
                        " WHERE Username='" + username + "'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        //find user by username to check if there are no duplicates when inserting new account
        public bool FindUser(string username) {
            string stmt = "SELECT * FROM Users WHERE Username='" + username + "'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }

            string data = "not found";

            if (reader != null) {
                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString() + " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetString(2) + " ";
                    data += reader.GetDouble(3) + " ";
                    data += "\n";
                }
                reader.Close();
            }

            if (data != "not found")
                return true;
            else
                return false;
        }


        private void CreateWinnersTable() {
            string stmt = "CREATE TABLE IF NOT EXISTS Winners(ID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT, Winnings INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        public void InsertWinner(string username, int winnings) {
            string stmt = "INSERT INTO Winners(Username, Winnings) VALUES('" + username + "'," + winnings + ")";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        public string SelectWinners() {
            string stmt = "SELECT * FROM Winners ORDER BY Winnings DESC";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
                Trace.WriteLine("Winners Selected");
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }

            string data = "";
            int c = 1;
            if (reader != null) {
                while (reader.Read()) {
                    data += c.ToString() + "                  ";
                    data += reader.GetString(1) + "                  ";
                    data += reader.GetInt32(2).ToString() + " ";
                    data += "\n";
                    c++;
                }
                reader.Close();

                return data;
            }

            return null;
        }

        public double GetBalance(string username) {
            string stmt = "SELECT Balance FROM Users WHERE Username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;
            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
            double balance = 1;
            if (reader != null) {
                while (reader.Read()) {
                    balance = reader.GetDouble(0);
                }
                return balance;
            }
            return 0;
        }
    }
}