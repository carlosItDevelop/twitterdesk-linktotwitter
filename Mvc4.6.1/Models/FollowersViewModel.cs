using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class FollowersViewModel
    {
        //[DisplayName("Image")]
        //[DataType(DataType.ImageUrl)]
        //public string ImageUrl { get; set; }

        //[DisplayName("Screen Name")]
        //public string ScreenName { get; set; }

        //[DisplayName("Count")]
        //public int Count { get; set; }

        [DisplayName("User Id")]
        public string UserID { get; set; }

        /*

            Name	    Purpose	                        Type	Required
            ============================================================
            Count	    Number of IDs to return         int	    no
            Cursor	    Separates results into pages	long	no
            ScreenName	Screen name of user	            string	only if userID is empty
            UserID	    ID of user	                    string	only if screenName is empty             

         */
    }
}