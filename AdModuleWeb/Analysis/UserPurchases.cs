using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace AdModuleWeb.Analysis
{

    public class products
    {
        private int pid, prod_price;
        private string prod_name;

        public products()
        {

        }
       
    }

    // Existing UserPurchases objects needed to be loaded from db on log in
    public class UserPurchases
    {
        protected int user_id;

        // in following iteration, this dictionary to be modified to use userID as the unique key and the value will be a product object
        // that stores product id, name, and frequnecy 
        protected Dictionary<string, int> product_frequency = new Dictionary<string, int>();


        //variables to monitor how much they purchase at a given price point 
        protected double session_avg_product_price;
        protected double session_subtotal;
        protected double historical_avg_prod_price;
        protected double historical_subtotal;

        protected UserPurchases()
        {
            //load historical data and product freqeuency from database
        }
  
        public void AddFrequency(List<string> products)
        {
            int frequency = 1;
            foreach (var key in product_frequency.Keys)
            {
                foreach (var p in products)
                {
                    if (p == key)
                    {
                        product_frequency[key] += frequency;
                    }
                    else
                    {
                        product_frequency.Add(p, frequency);
                    }
                }
            }
        }

        //next iteration to replace List with products object 
        public void calculateAverages(string subtotal, List<string> products)
        {
            int historical_count = 0;

            session_subtotal = Int32.Parse(subtotal);
            session_avg_product_price = session_subtotal / products.Count();

            foreach(var key in product_frequency.Keys)
            {
                historical_count += product_frequency[key];
            }

            historical_avg_prod_price = (session_subtotal + historical_subtotal) / (products.Count() + historical_count);
        }
    }


    //class that uses UserPurchases data to predict and send correct ads to Cart and Product pages 
    public class AdPrediction : UserPurchases
    {
  

        protected Dictionary <int, products> productInfo;

        AdPrediction()
        {
            

        }




        // a method that finds the two most frequented products of a user and suggests complimentary adds to said user                                                                                                                                                                                                                                                                                                                                                                                                              
        List<string> suggestAd()
        {

           //dummy
            product_frequency.Add("Body Wash", 2);
            product_frequency.Add("Blender", 4);
            product_frequency.Add("Screen Protector", 7);
            product_frequency.Add("Icy Hot Pack", 5);

            //orders product dictionary in acending order by most frequented
            product_frequency = product_frequency.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            var count = 2;
            //place top two most purchased items and place them in a list 



            //mostPurchased will be object of type products in next iteration 
            var mostPurchased = new List<string>(product_frequency.Keys.Take(count).ToList());
            var suggestedAd = new List<string>();

            //use mostPurchased data to interact with ad creative class
                // send mostPurchased data to send to AD creative class
                // (outside of scope but Ad Creative Class should use data to create/retrieve appropriate ad)
                // **need table in db that uses a given product id for a user to map to complementary items **

            //dummy  complimentary suggestions based on top two
            var suggestScreenProtect = new List<string>();
            suggestScreenProtect.Add("Charger, 39.99");
            suggestScreenProtect.Add("OtterBox Phone Case, 69.99");
            suggestScreenProtect.Add("Ipad 499.99");

            var suggestBlender = new List<string>();
            suggestBlender.Add("Air Fryer, 89.99");
            suggestBlender.Add("Sterling Knife Set, 39.99");
            suggestBlender.Add("Microvave, 139.99");

            count = 0;

            //once product object, and AD creative class implented will call Add Creative object to retrieve/create appropriate ad
            foreach( var prod in mostPurchased)
            {
                if(historical_avg_prod_price < 50 )
                {
                    suggestedAd.Add(suggestScreenProtect[0]);
                    suggestedAd.Add(suggestBlender[1]);

                }
                else if (historical_avg_prod_price > 50 && historical_avg_prod_price < 100 )
                {
                    suggestedAd.Add(suggestScreenProtect[1]);
                    suggestedAd.Add(suggestBlender[1]);
                }
                else
                {
                    suggestedAd.Add(suggestScreenProtect[2]);
                    suggestedAd.Add(suggestBlender[2]);
                }
               

            }

            return suggestedAd;
        }



    }
}

