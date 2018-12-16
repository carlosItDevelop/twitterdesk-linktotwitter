


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

    }
}