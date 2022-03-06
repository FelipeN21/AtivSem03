using AtivSem03.Data;
using AtivSem03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AtivSem03.Controllers
{

    //Teste dos metodos Post,Delete, etc -> Realizados Via ThunderCliente do VsCode -> 
    //Caso necessario teste via Navegador, ou por algum cliente de request alterando para os tipos de request
    public class AlunoController : Controller
    {
     
        [HttpGet("/AlunoController")]
        public ActionResult IndexAlunos()
        {
            return View();
        }



        
       [HttpGet("/Aluno/Adicionar")]
        public ActionResult Adicionar(int id)
        {
            try
            {
                var aluno = new Aluno { nome = "Homem de ferro22", telefone = "31984049627", matricula = 12, carroID = 1 };
                using (var contexto = new AlunoContext())
                {
                    contexto.Alunos.Add(aluno);
                    contexto.SaveChanges();
                    return Ok(aluno);
                }
               
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }



        [HttpGet("Aluno/Read")]
        public ActionResult Read()
        {
            try { 
            using (var contexto = new AlunoContext())
            {
               var listAluno = contexto.Alunos.ToList();
               
                return Ok(listAluno);
            }
            }catch (Exception ex) { return Ok(ex.Message); }
        }


       
        [HttpGet("/Aluno/Update{matriculaP}")]
        public ActionResult Update(int matriculaP)
        {
            try { 
            
            using (var contexto = new AlunoContext())
            {
                var busca = contexto.Alunos.Where(B => B.matricula == matriculaP).FirstOrDefault();

                busca.nome = "Felipe Nepomuceno Apenas";
                
                 contexto.SaveChanges();
                return Ok(busca);
            }
            }catch(Exception ex) { return Ok(ex.Message); }

           
        }



        [HttpGet("/Aluno/Delete{id}")]
        public ActionResult Delete(int id)
        {
            try { 
            using (var contexto = new AlunoContext())
            {
                var aluno = contexto.Alunos.Where(B => B.Id == id).Single();

                contexto.Alunos.Remove(aluno);
                contexto.SaveChanges();
                return Ok();
            }
            }catch (Exception ex) { return Ok(ex.Message); }
        }
  
      
    }
}
