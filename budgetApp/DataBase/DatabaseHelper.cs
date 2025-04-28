using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace budgetApp.DataBase
{
    public class DatabaseHelper
    {
        private string _connectionString = "Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private object _userId;

        public void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool RecordExists(int userId, string category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM PieChartData WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void UpdateRecord(int userId, string category, decimal amount)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                // Aktualizacja w PieChartData
                string updateQuery = "UPDATE PieChartData SET Amount = Amount + @Amount, Date = @Date WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.ExecuteNonQuery();

                // Dodawanie tych samych danych do LineChartData
                string insertLineChartQuery = "INSERT INTO LineChartData (UserId, Amount, Date) VALUES (@UserId, @Amount, @Date)";
                SqlCommand cmdLineChart = new SqlCommand(insertLineChartQuery, con);
                cmdLineChart.Parameters.AddWithValue("@UserId", userId);
                cmdLineChart.Parameters.AddWithValue("@Amount", amount);
                cmdLineChart.Parameters.AddWithValue("@Date", DateTime.Now);
                cmdLineChart.ExecuteNonQuery();
            }
        }


        public void InsertRecord(int userId, string category, decimal amount)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                // Wstawianie danych do PieChartData
                string insertQuery = "INSERT INTO PieChartData (UserId, Category, Amount, Date) VALUES (@UserId, @Category, @Amount, @Date)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();

                // Dodawanie tych samych danych do LineChartData
                string insertLineChartQuery = "INSERT INTO LineChartData (UserId, Amount, Date) VALUES (@UserId, @Amount, @Date)";
                SqlCommand cmdLineChart = new SqlCommand(insertLineChartQuery, con);
                cmdLineChart.Parameters.AddWithValue("@UserId", userId);
                cmdLineChart.Parameters.AddWithValue("@Amount", amount);
                cmdLineChart.Parameters.AddWithValue("@Date", DateTime.Now);
                cmdLineChart.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(int userId, string category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                // Usuwanie z PieChartData
                string deleteQuery = "DELETE FROM PieChartData WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.ExecuteNonQuery();

                // Usuwanie z LineChartData
                string deleteLineChartQuery = "DELETE FROM LineChartData WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmdLineChart = new SqlCommand(deleteLineChartQuery, con);
                cmdLineChart.Parameters.AddWithValue("@UserId", userId);
                cmdLineChart.Parameters.AddWithValue("@Category", category);
                cmdLineChart.ExecuteNonQuery();
            }
        }


        public void UpdateTotalRecord(int userId, decimal amountToSubtract)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string updateQuery = @"
            UPDATE Total
            SET Value = Value - @Amount
            WHERE UserId = @UserId AND Label = 'Wykres'";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Amount", amountToSubtract);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GetSavingChartData(int userId, string description)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT Label FROM ChartGoalsData WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string label = reader.GetString(0);

                        }
                    }
                }
            }
        }

        //public (decimal goalAmount, decimal howMuch) GetGoalAndHowMuch(int userId, string description)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        con.Open();
        //        string query = "SELECT Goal, HowMuch FROM ChartGoalsData WHERE UserId = @UserId AND Label = @Description";

        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.Parameters.AddWithValue("@UserId", userId);
        //            cmd.Parameters.AddWithValue("@Description", description);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    decimal goalAmount = reader.GetDecimal(0);  // Goal
        //                    decimal howMuch = reader.GetDecimal(1);     // HowMuch
        //                    return (goalAmount, howMuch);
        //                }
        //                else
        //                {
        //                    return (0, 0); // Zwracamy 0, jeśli nie znaleziono danych
        //                }
        //            }
        //        }
        //    }
        //}

        public List<SavingGoal> GetSavingChartData(int userId)
        {
            List<SavingGoal> savingGoals = new List<SavingGoal>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT Label, Goal, HowMuch FROM ChartGoalsData WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var goal = new SavingGoal
                            {
                                Label = reader["Label"].ToString(),
                                GoalAmount = reader.GetDecimal(reader.GetOrdinal("Goal")),
                                HowMuch = reader.GetDecimal(reader.GetOrdinal("HowMuch"))
                            };
                            savingGoals.Add(goal);
                        }
                    }
                }
            }

            return savingGoals;
        }

        public void AddSavingGoal(int userId, string description, decimal goalAmount, decimal howMuch)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                // Wstawianie danych do ChartGoalsData
                string insertQuery = "INSERT INTO ChartGoalsData (UserId, Label, Goal, HowMuch, Date) VALUES (@UserId, @Label, @Goal, @HowMuch, @Date)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Label", description);
                    cmd.Parameters.AddWithValue("@Goal", goalAmount);
                    cmd.Parameters.AddWithValue("@HowMuch", howMuch);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                // Dodawanie danych do LineChartData
                string insertLineChartQuery = "INSERT INTO LineChartData (UserId, Amount, Date) VALUES (@UserId, @Amount, @Date)";
                using (SqlCommand cmdLineChart = new SqlCommand(insertLineChartQuery, con))
                {
                    cmdLineChart.Parameters.AddWithValue("@UserId", userId);
                    cmdLineChart.Parameters.AddWithValue("@Amount", howMuch);  // Możesz przechowywać 'howMuch' jako 'Amount'
                    cmdLineChart.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmdLineChart.ExecuteNonQuery();
                }
            }
        }

        public void AddAddiction(int userId, string addictionName, decimal amount)
        {
            string query = "INSERT INTO Addictions (UserId, AddictionName, Amount, Date) VALUES (@UserId, @AddictionName, @Amount, @Date)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AddictionName", addictionName),
                new SqlParameter("@Amount", amount),
                new SqlParameter("@Date", DateTime.Now)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void UpdateAddictionAmount(int userId, string addictionName, decimal amount)
        {
            string query = "UPDATE Addictions SET Amount = Amount + @Amount WHERE UserId = @UserId AND AddictionName = @AddictionName";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@AddictionName", addictionName);

                    cmd.ExecuteNonQuery();
                }

                // Dodanie tych samych danych do LineChartData
                string insertLineChartQuery = "INSERT INTO LineChartData (UserId, Amount, Date) VALUES (@UserId, @Amount, @Date)";
                using (SqlCommand cmdLineChart = new SqlCommand(insertLineChartQuery, con))
                {
                    cmdLineChart.Parameters.AddWithValue("@UserId", userId);
                    cmdLineChart.Parameters.AddWithValue("@Amount", amount);  // Przechowywanie aktualnej kwoty wydatków
                    cmdLineChart.Parameters.AddWithValue("@Date", DateTime.Now);  // Dodawanie daty
                    cmdLineChart.ExecuteNonQuery();
                }
            }
        }

        public List<(string Name, decimal Amount)> GetAddictionsWithAmounts(int userId)
        {
            List<(string Name, decimal Amount)> addictions = new List<(string Name, decimal Amount)>();

            string query = "SELECT AddictionName, Amount FROM Addictions WHERE UserId = @UserId ORDER BY Date DESC";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            decimal amount = reader.GetDecimal(1);
                            addictions.Add((name, amount));
                        }
                    }
                }
            }

            return addictions;
        }

        public List<decimal> GetMonthlyExpenses(int userId)
        {
            List<decimal> monthlyExpenses = new List<decimal>(new decimal[12]); // Inicjalizacja listy 12 elementów (po jednym na każdy miesiąc)

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"
            SELECT MONTH(Date) AS Month, SUM(Amount) AS TotalAmount
            FROM LineChartData
            WHERE UserId = @UserId
            GROUP BY MONTH(Date)
            ORDER BY MONTH(Date)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int month = reader.GetInt32(0); // Miesiąc
                            decimal totalAmount = reader.GetDecimal(1); // Suma wydatków za dany miesiąc

                            monthlyExpenses[month - 1] = totalAmount; // Przechowywanie sumy w odpowiednim indeksie miesiąca
                        }
                    }
                }
            }

            return monthlyExpenses;
        }

        public List<decimal> GetWeeklyExpenses(int userId)
        {
            List<decimal> weeklyExpenses = new List<decimal>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"
            SELECT CAST(Date AS DATE) AS Day, SUM(Amount) AS TotalAmount
            FROM LineChartData
            WHERE UserId = @UserId AND Date >= DATEADD(DAY, -6, GETDATE())
            GROUP BY CAST(Date AS DATE)
            ORDER BY Day";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal totalAmount = reader.GetDecimal(1);
                            weeklyExpenses.Add(totalAmount);
                        }
                    }
                }
            }

            return weeklyExpenses;
        }

        //public List<decimal> GetMonthlyDailyExpenses(int userId)
        //{
        //    List<decimal> dailyExpenses = new List<decimal>();

        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        con.Open();
        //        string query = @"
        //    SELECT DAY(Date) AS Day, SUM(Amount) AS TotalAmount
        //    FROM LineChartData
        //    WHERE UserId = @UserId AND MONTH(Date) = MONTH(GETDATE()) AND YEAR(Date) = YEAR(GETDATE())
        //    GROUP BY DAY(Date)
        //    ORDER BY Day";

        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.Parameters.AddWithValue("@UserId", userId);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    decimal totalAmount = reader.GetDecimal(1);
        //                    dailyExpenses.Add(totalAmount);
        //                }
        //            }
        //        }
        //    }

        //    return dailyExpenses;
        //}


        public (List<decimal> amounts, List<string> categories) GetPieChartData(int userId)
        {
            List<string> categories = new List<string>();
            List<decimal> amounts = new List<decimal>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();

                    // Zabezpieczanie zapytania SQL
                    string query = "SELECT Amount, Category FROM PieChartData WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Użycie parametru przekazywanego do metody
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Sprawdzanie danych w bazie
                            while (reader.Read())
                            {
                                string categoryFromDb = reader["Category"]?.ToString() ?? "Brak kategorii";
                                decimal amountFromDb = reader["Amount"] != DBNull.Value ? Convert.ToDecimal(reader["Amount"]) : 0;

                                categories.Add(categoryFromDb);
                                amounts.Add(amountFromDb);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania danych dla wykresu kołowego: " + ex.Message);
                }

                return (amounts, categories);
            }
        }

        public decimal GetTotalValue(int userId, string label)
        {
            decimal totalValue = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Label", label);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            totalValue = (decimal)result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania danych z tabeli Total: " + ex.Message);
                }
            }

            return totalValue;
        }

        //public decimal UpdateTotalLabel(int userId, string label)
        //{
        //    decimal totalValue = 0;

        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            con.Open();

        //            // Pobierz wartość z bazy danych
        //            string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@UserId", userId);
        //            cmd.Parameters.AddWithValue("@Label", label);

        //            var result = cmd.ExecuteScalar();

        //            if (result != null)
        //            {
        //                totalValue = (decimal)result;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
        //        }
        //    }

        //    return totalValue;
        //}

        public decimal UpdataotalValue(int userId, string label)
        {
            decimal totalValue = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();

                    // Pobierz wartość z bazy danych
                    string query = "SELECT Value FROM Total WHERE UserId = @UserId AND Label = @Label";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Label", label);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        totalValue = (decimal)result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
                }
            }

            return totalValue;
        }
        public static void UpdateSavingGoalAmount(int userId, string label, decimal amountToAdd)
        {
            // Convert _connectionString to static to resolve CS0120 error
            string connectionString = "Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1. Pobierz aktualną kwotę
                string selectQuery = "SELECT HowMuch FROM ChartGoalsData WHERE UserId = @UserId AND Label = @Label";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@UserId", userId);
                selectCmd.Parameters.AddWithValue("@Label", label);

                var result = selectCmd.ExecuteScalar();

                if (result != null)
                {
                    decimal currentAmount = (decimal)result;
                    decimal newAmount = currentAmount + amountToAdd;

                    // 2. Zaktualizuj
                    string updateQuery = "UPDATE ChartGoalsData SET HowMuch = @NewAmount WHERE UserId = @UserId AND Label = @Label";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewAmount", newAmount);
                    updateCmd.Parameters.AddWithValue("@UserId", userId);
                    updateCmd.Parameters.AddWithValue("@Label", label);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Saving goal not found.");
                }
            }
        }

        public void DeleteCompletedGoals(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string deleteQuery = @"
            DELETE FROM ChartGoalsData
            WHERE UserId = @UserId AND HowMuch >= Goal";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public class SavingGoal
        {
            public string Label { get; set; }
            public decimal GoalAmount { get; set; }
            public decimal HowMuch { get; set; }
        }



    }
}

