using AtivSem03.Data;
using AtivSem03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtivSem03.Controllers
{
    public class CarroController : Controller
    {

        //Teste dos metodos Post,Delete, etc -> Realizados Via ThunderCliente do VsCode -> 
        //Caso necessario teste via Navegador, trocar para Get


        [HttpGet("/Carros/IndexCarros")]
        public ActionResult IndexCarros()
        {
            return View();
        }



        
        [HttpGet("/Carro/Adicionar")]
        public ActionResult Adicionar(int id)
        {
            try
            {
                var carro = new Carro { documento = 70566, modelo = "MonzaTurbo" , placa = "KLL-2020"};
                using (var contexto = new AlunoContext())
                {
                    contexto.Carros.Add(carro);
                    contexto.SaveChanges();
                    return Ok(carro);
                }
                
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }



        [HttpGet("Carro/Read")]
        public ActionResult Read()
        {
            try
            {
                using (var contexto = new AlunoContext())
                {
                    var listCarros = contexto.Carros.ToList();

                    return Ok(listCarros);
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }


       
        [HttpGet("/Carro/Update{documentoP}")]
        public ActionResult Update(int documentoP)
        {
            try
            {
                
                using (var contexto = new AlunoContext())
                {
                    var busca = contexto.Carros.Where(B => B.documento == documentoP).FirstOrDefault();

                    busca.modelo = "Carro Teste Inserido Update";
                    
                    contexto.SaveChanges();
                    return Ok(busca);
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }

           
        }



        [HttpGet("/Carro/Delete{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var contexto = new AlunoContext())
                {
                    var carro = contexto.Carros.Where(B => B.Id == id).Single();

                    contexto.Carros.Remove(carro);
                    contexto.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }

    }
}
