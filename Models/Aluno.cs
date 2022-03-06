using Microsoft.EntityFrameworkCore;

namespace AtivSem03.Models
{
    
        public class Aluno
        {
         public int Id { get; set; }
        public int matricula { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }

        public int carroID { get; set; }


}
    
}
