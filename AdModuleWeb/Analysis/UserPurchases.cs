namespace AdModuleWeb.Analysis
{
    public class UserPurchases
    {
        protected int user_id;

        //private Dictionary<string, int> category_frequency = new Dictionary<string, int>();
        //- contemplating on necessity of monitoring this/if it will even be made available  


        protected Dictionary<string, int> product_frequency = new Dictionary<string, int>();
        //variables to monitor how much they purchase at a given price point 
        protected double avg_product_price;
        protected double subtotal;


        protected UserPurchases()
        {

        }
        //may handle JSON in future 
        public UserPurchases(int user_id, double product_count, double subtotal)
        {
            this.user_id = user_id;

            avg_product_price = subtotal / product_count;

            //load data from db into dictionary using entity framework 


        }




        public void AddFrequency(List<string> products)
        {
            foreach (var key in product_frequency.Keys)
            {
                foreach (var p in products)
                {
                    if (p == key)
                    {
                        product_frequency[key] += 1;
                    }
                    else
                    {
                        product_frequency.Add(p, 1);
                    }
                }
            }
        }

        //retrieve of most common products purchased and average price from db using user_id,
        //avg_product_price and product_frequency 


        //


    }


    //class that uses UserPurchases data to predict and send correct ads to Cart and Product pages 
    public class PredictAd : UserPurchases
    {
        //when customer logs in we need notification from Profile that they have logged in 

        protected string price;
        protected string imgUrl;
        protected string productName;
        protected string productInfo;

        PredictAd()
        {
            this.price = string.Empty;
            this.imgUrl = string.Empty;
            this.productName = string.Empty;
            this.productInfo = string.Empty;

        }




        List<string> suggestAd()
        {
            var adDetails = new List<string>();

            ///dummy data
            string imgURL = "https://picsum.photos/650/250";
            string productName = "cloud painting";
            string price = "34.99";

            //get list of most common products purchased and average price from db using user_id 



            //use frequency to weigh what would be most likely to entice customer

            foreach (var key in product_frequency)
            {

            }

            adDetails.Add(imgUrl);

            adDetails.Add(productName);

            adDetails.Add(price);

            return adDetails;
        }



    }
}

