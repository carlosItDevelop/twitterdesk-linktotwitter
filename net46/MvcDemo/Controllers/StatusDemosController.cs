using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcDemo.Models;
using LinqToTwitter;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MvcDemo.Controllers
{
    public class StatusDemosController : Controller
    {

        #region: todos meno seguidores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tweet()
        {
            var sendTweetVM = new SendTweetViewModel
            {
                Text = "Testing async LINQ to Twitter in MVC - " + DateTime.Now.ToString()
            };

            return View(sendTweetVM);
        }

        [HttpPost]
        [ActionName("Tweet")]
        public async Task<ActionResult> TweetAsync(SendTweetViewModel tweet)
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            Status responseTweet = await ctx.TweetAsync(tweet.Text);

            var responseTweetVM = new SendTweetViewModel
            {
                Text = "Testing async LINQ to Twitter in MVC - " + DateTime.Now.ToString(),
                Response = "Tweet successful! Response from Twitter: " + responseTweet.Text
            };

            return View(responseTweetVM);
        }

        [ActionName("HomeTimeline")]
        public async Task<ActionResult> HomeTimelineAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var tweets =
                await
                (from tweet in ctx.Status
                 where tweet.Type == StatusType.Home
                 select new TweetViewModel
                 {
                     ImageUrl = tweet.User.ProfileImageUrl,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text
                 })
                .ToListAsync();

            return View(tweets);
        }




        [ActionName("ListingFollowers")]
        public async Task<ActionResult> ListingFollowersAsync()
        {
            List<string> amigos = new List<string>();
            List<FollowersViewModel> fView = new List<FollowersViewModel>();



            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);  //UserID = "1068723410757435393"
            var seguidores =
                await
                (from follower in ctx.Friendship
                 where follower.Type == FriendshipType.FollowerIDs && follower.UserID == CredenciaisAuth.UserID.ToString()
                 select follower).SingleOrDefaultAsync();

            if (seguidores != null &&
                seguidores.IDInfo != null &&
                seguidores.IDInfo.IDs != null)
            {
                seguidores.IDInfo.IDs.ForEach(id => amigos.Add(id.ToString()));
                foreach (var item in amigos)
                {
                    fView.Add(new FollowersViewModel
                    {
                        UserID = item
                    });
                }
            }
            return View(fView);
        }

        #endregion


        [ActionName("Seguidores")]
        public async Task<ActionResult> SeguidoresAsync()
        {


            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };
            var ctx = new TwitterContext(auth);
            var friendship =
                await
                (from friend in ctx.Friendship
                 where friend.Type == FriendshipType.FollowersList &&
                //friend.ScreenName == "desk_tw"
                friend.ScreenName == CredenciaisAuth.ScreenName
                 select friend).SingleOrDefaultAsync();
            List<SeguidoresViewModel> seguidores = new List<SeguidoresViewModel>();
            if (friendship != null && friendship.Users != null)
            {
                foreach (var item in friendship.Users)
                {
                    var seguidor = new SeguidoresViewModel
                    {
                        ProfileImageUrl = item.ProfileImageUrl,
                        UserIDResponse = item.UserIDResponse,
                        ScreenNameResponse = item.ScreenNameResponse,
                        Description = item.Description,
                        Verified = item.Verified
                    };
                    seguidores.Add(seguidor);
                }

                //var jsonSeguidores = JsonConvert.SerializeObject(friendship);
                //var jsonSeguidoresUser = JsonConvert.SerializeObject(seguidores);

                return View(seguidores);
            }
            return RedirectToAction("Index", "StatusDemos");
        }


        [ActionName("TrendsLocator")]
        public async Task<ActionResult> TrendsLocatorAsync()
        {

            // WoeID=>Brazil = 23424768

            var cokies = Request.Cookies["twitterdesk"];
            var cookieCollection = cokies.Value;
            var jsonTrendsLocator = JsonConvert.DeserializeObject(cookieCollection);


            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };
            var ctx = new TwitterContext(auth);

            var trendsResponse =
                            await
                            (from trend in ctx.Trends
                             where trend.Type == TrendType.Available
                             select trend)
                            .SingleOrDefaultAsync();

            List<TrendsLocatorViewModel> listaLocator = new List<TrendsLocatorViewModel>();
            if (trendsResponse != null && trendsResponse.Locations != null)
            {
                foreach (var item in trendsResponse.Locations)
                {
                    var trendsloc = new TrendsLocatorViewModel
                    {
                        WoeID = item.WoeID,
                        Name = item.Name,
                        Url = item.Url,
                        Country = item.Country,
                        CountryCode = item.CountryCode,
                        ParentID = item.ParentID,
                        PlaceTypeName = item.PlaceTypeName,
                        PlaceTypeNameCode = item.PlaceTypeNameCode
                    };
                    listaLocator.Add(trendsloc);
                }
            }

            return View(listaLocator);
        }

        [ActionName("TrendTopics")]
        public async Task<ActionResult> TrendTopicsAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };
            var ctx = new TwitterContext(auth);

            var trend =
                await
                (from trnd in ctx.Trends
                 where trnd.Type == TrendType.Closest &&
                        trnd.WoeID == 23424768
                 select trnd)
                .SingleOrDefaultAsync();

            if (trend != null && trend.Locations != null)
                trend.Locations.ForEach(
                    loc => Debug.WriteLine(
                        "Name: {0}, Country: {1}, WoeID: {2}",
                        loc.Name, loc.Country, loc.WoeID));

            return View("Index");
        }


        [ActionName("UploadImage")]
        public async Task<ActionResult> UploadImageAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var twitterCtx = new TwitterContext(auth);

            string status = $"Testing multi-image tweet #Linq2Twitter £ {DateTime.Now}";
            string mediaCategory = "tweet_image";

            string path = Server.MapPath("..\\Content\\200xColor_2.png");
            var imageUploadTasks =
                new List<Task<Media>>
                {
                    twitterCtx.UploadMediaAsync(System.IO.File.ReadAllBytes(path), "image/jpg", mediaCategory),
                };

            await Task.WhenAll(imageUploadTasks);

            List<ulong> mediaIds =
                (from tsk in imageUploadTasks
                 select tsk.Result.MediaID)
                .ToList();

            Status tweet = await twitterCtx.TweetAsync(status, mediaIds);

            return View(
                new TweetViewModel
                {
                    ImageUrl = tweet.User.ProfileImageUrl,
                    ScreenName = tweet.User.ScreenNameResponse,
                    Text = tweet.Text
                });
        }
    }
}