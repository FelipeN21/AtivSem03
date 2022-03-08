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

        [HttpGet("/Aluno/AdicionarAluno")]
        public ActionResult AdicionarAluno()
        {
            return View();
        }
        [HttpPost("/Aluno/AdicionarAluno")]
        public ActionResult AdicionarAluno(Aluno aluno)
        {
            try
            {
                
                using (var contexto = new AlunoContext())
                {
                    contexto.Alunos.Add(aluno);
                    contexto.SaveChanges();
                    return View("IndexAlunos");
                }
               
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }



        [HttpGet("Aluno/Response/ReadAlunos")]
        public ActionResult ReadAlunos()
        {
            try { 
            using (var contexto = new AlunoContext())
            {
               var listAluno = contexto.Alunos.ToList();
               ViewBag.Alunos = listAluno;
                return //Ok(listAluno);
                    View();
            }
            }catch (Exception ex) { return Ok(ex.Message); }
        }



        [HttpGet("/Aluno/UpdateAluno")]
        public ActionResult UpdateAluno()
        {


            return View();

        }



        [HttpPost("/Aluno/UpdateAluno")]
        public ActionResult UpdateAluno(Aluno aluno)
        {
            try { 
            
            using (var contexto = new AlunoContext())
            {
                    var busca = contexto.Alunos.Where(B => B.Id == aluno.Id).FirstOrDefault();
                    
                    
                    busca.nome = aluno.nome;
                    busca.matricula = aluno.matricula;
                    busca.telefone = aluno.nome;
                    busca.carroID = aluno.carroID;
                    contexto.SaveChanges();
                    return View("IndexAlunos");
                }
            }catch(Exception ex) { return Ok(ex.Message); }

           
        }



        [HttpGet("/Aluno/DeleteAluno")]
        public ActionResult DeleteAluno()
        {
            try
            {
                return View();
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }



        [HttpPost("/Aluno/DeleteAluno")]
        public ActionResult DeleteAluno(Aluno aluno)
        {
            try { 
            using (var contexto = new AlunoContext())
            {
             var toDelete = contexto.Alunos.Where(B => B.Id == aluno.Id).Single();

                contexto.Alunos.Remove(toDelete);
                contexto.SaveChanges();
                    Console.Write(aluno.Id);
                    return View("IndexAlunos");
                }
            }catch (Exception ex) { return Ok(ex.Message); }
        }
  
      
    }
}
