


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class SeguidoresViewModel
    {
        [DisplayName("Id")]
        public string UserIDResponse { get; set; }

        [DisplayName("Nome do usuário")]
        public string ScreenNameResponse { get; set; }

        [DisplayName("Bio")]
        public string Description { get; set; }

        [DisplayName("Verificado")]
        public bool Verified { get; set; }

        [DisplayName("Imagem de Perfil")]
        [DataType(DataType.ImageUrl)]
        public string ProfileImageUrl { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Fechado")]
        public bool Protected { get; set; }

        [DisplayName("Seguindo")]
        public int FriendsCount { get; set; }

        [DisplayName("Seguidores")]
        public int FollowersCount { get; set; }

        [DisplayName("Te Seguem")]
        public bool Following { get; set; }

        [DisplayName("Media Liberada")]
        public bool ShowAllInlineMedia { get; set; }

        [DisplayName("Linguagem")]
        public string LangResponse { get; set; }

    }
}