using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace USStockTrading
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "2QGYUBB5FY4BGM3E"; // Alpha Vantage, issued API key
        private List<string> dates = new List<string>(); // 日付リスト
        private List<double> prices = new List<double>(); // 価格リスト
        private List<double> volumes = new List<double>(); // 取引量リスト

        public Form1()
        {
            InitializeComponent();
            btnFetch.Click += btnFetch_Click;
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ボタンがクリックされました！");

            string symbol = txtSymbol.Text.Trim();
            if (string.IsNullOrWhiteSpace(symbol))
            {
                MessageBox.Show("株式シンボルを入力してください。");
                return;
            }

            // API Call
            string jsonData = await FetchStockData(symbol);
            if (!string.IsNullOrEmpty(jsonData))
            {
                ProcessStockData(jsonData);
            }
            else
            {
                MessageBox.Show("データを取得できませんでした。");
            }
        }

        private async Task<string> FetchStockData(string symbol)
        {
            try
            {
                string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={ApiKey}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        MessageBox.Show("API 呼び出し失敗: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー発生: " + ex.Message);
            }
            return null;
        }
        private void ProcessStockData(string jsonData)
        {
            try
            {
                JObject json = JObject.Parse(jsonData);
                var timeSeries = json["Time Series (Daily)"] as JObject;

                if (timeSeries == null)
                {
                    MessageBox.Show("株式データがありません。");
                    return;
                }

                // 日付と価格データ抽出
                dates.Clear(); // 既存データ初期化
                volumes.Clear();
                prices.Clear();

                int counter = 0;
                foreach (var item in timeSeries)
                {
                    if (counter >= 30) break; // 直近30日分のみ処理

                    string date = item.Key;
                    var details = item.Value;
                    double closePrice = double.Parse(details["4. close"].ToString());
                    double volume = double.Parse(details["5. volume"].ToString());

                    dates.Add(date);
                    prices.Add(closePrice);
                    volumes.Add(volume);

                    counter++;
                }

                // チャート更新
                UpdateChart(dates, prices, volumes);

                // 買い・売りの推奨
                GenerateRecommendations(prices, volumes);

            }
            catch (Exception ex)
            {
                MessageBox.Show("データ処理中にエラー発生: " + ex.Message);
            }
        }

        private void UpdateChart(List<string> dates, List<double> prices, List<double> volumes)
        {
            chartStock.Series.Clear();

            // 株価シリーズ追加
            var priceSeries = new Series
            {
                Name = "終値",
                ChartType = SeriesChartType.Line
            };

            double minPrice = prices.Min();
            double maxPrice = prices.Max();

            for (int i = 0; i < dates.Count; i++)
            {
                priceSeries.Points.AddXY(dates[i], prices[i]);
            }

            chartStock.Series.Add(priceSeries);

            // Y軸の範囲設定（最小値と最大値を調整）
            chartStock.ChartAreas[0].AxisY.Minimum = Math.Floor(minPrice * 0.97); // 3% 低く設定
            chartStock.ChartAreas[0].AxisY.Maximum = Math.Ceiling(maxPrice * 1.03); // 3% 高く設定
        }

        private void GenerateRecommendations(List<double> prices, List<double> volumes)
        {
            lstRecommendations.Items.Clear();

            for (int i = 1; i < prices.Count; i++)
            {
                if (prices[i] > prices[i - 1] * 1.03) // 3% 上昇
                {
                    lstRecommendations.Items.Add($"{dates[i]}: 買い推奨"); // 日付を出力
                }
                else if (prices[i] < prices[i - 1] * 0.97) // 3% 下落
                {
                    lstRecommendations.Items.Add($"{dates[i]}: 売り推奨"); // 日付を出力
                }
            }

        }

        private void btnAddSymbol_Click(object sender, EventArgs e)
        {
            // SymbolListFormを開いて、事前入力されたシンボルと会社名を表示
            SymbolListForm symbolForm = new SymbolListForm();
            symbolForm.Show();
        }
    }
}
