using LinqToTwitter;
using System.Collections.Generic;

namespace MvcDemo.Services
{
    public class UserServices
    {
        public UserServices()
        {
        }


        /* =======/ =============================== */
        //var listUser = friendship.Users;
        //listUser = JsonConvert.SerializeObject(friendship.Users);  // Verificar como converter List<User> em string
        /* =======/ =============================== */

        List<User> meusSeguidores = new List<User>();
        public List<User> GetListaDeUsuarios(List<User> listaUsuarios)
        {
            foreach(var item in listaUsuarios)
            {
                var user = new User
                {
                    BannerSizes = item.BannerSizes,
                    Categories = item.Categories,
                    ContributorsEnabled = item.ContributorsEnabled,
                    Count = item.Count,
                    CreatedAt = item.CreatedAt,
                    Cursor = item.Cursor,
                    DefaultProfile = item.DefaultProfile,
                    DefaultProfileImage = item.DefaultProfileImage,
                    Description = item.Description,
                    Email = item.Email,
                    FavoritesCount = item.FavoritesCount,
                    FollowersCount = item.FollowersCount,
                    Following = item.Following,
                    FollowRequestSent = item.FollowRequestSent,
                    FriendsCount = item.FriendsCount,
                    GeoEnabled = item.GeoEnabled,
                    ImageSize = item.ImageSize,
                    IncludeEntities = item.IncludeEntities,
                    IsTranslator = item.IsTranslator,
                    Lang = item.Lang,
                    LangResponse = item.LangResponse,
                    ListedCount = item.ListedCount,
                    Location = item.Location,
                    Name = item.Name, // Nome que aparece e não o "nikname", com o @
                    Notifications = item.Notifications,
                    Page = item.Page,
                    ProfileBackgroundColor = item.ProfileBackgroundColor,
                    ProfileBackgroundImageUrl = item.ProfileBackgroundImageUrl,
                    ProfileBackgroundImageUrlHttps = item.ProfileBackgroundImageUrlHttps,
                    ProfileBackgroundTile = item.ProfileBackgroundTile,
                    ProfileBannerUrl = item.ProfileBannerUrl,
                    ProfileImage = item.ProfileImage,
                    ProfileImageUrl = item.ProfileImageUrl,
                    ProfileImageUrlHttps = item.ProfileImageUrlHttps,
                    ProfileLinkColor = item.ProfileLinkColor,
                    ProfileSidebarBorderColor = item.ProfileSidebarBorderColor,
                    ProfileSidebarFillColor = item.ProfileSidebarFillColor,
                    ProfileTextColor = item.ProfileTextColor,
                    ProfileUseBackgroundImage = item.ProfileUseBackgroundImage,
                    Protected = item.Protected,
                    Query = item.Query,
                    ScreenName = item.ScreenName,
                    ScreenNameList = item.ScreenNameList,
                    ScreenNameResponse = item.ScreenNameResponse,
                    ShowAllInlineMedia = item.ShowAllInlineMedia,
                    SkipStatus = item.SkipStatus,
                    Slug = item.Slug,
                    Status = item.Status,
                    StatusesCount = item.StatusesCount,
                    TimeZone = item.TimeZone,
                    Type = item.Type,
                    Url = item.Url,
                    UserID = item.UserID,
                    UserIdList = item.UserIdList,
                    UserIDResponse = item.UserIDResponse,
                    UtcOffset = item.UtcOffset,
                    Verified = item.Verified
                };
                meusSeguidores.Add(user);
            }
            return meusSeguidores;
        }

    }
}