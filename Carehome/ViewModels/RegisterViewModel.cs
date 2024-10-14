using System.ComponentModel.DataAnnotations;

namespace Carehome.ViewModels
{
	public class RegisterViewModel
	{
        public int Id { get; set; }
		public string Email{ get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
		public string UserName { get; set; }
    }
}
