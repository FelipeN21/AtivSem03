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


        [HttpGet("/Carro/AdicionarCarro")]
        public ActionResult AdicionarCarro()
        {
            return View();
        }

        [HttpPost("/Carro/AdicionarCarro")]
        public ActionResult AdicionarCarro(Carro carro)
        {
            try
            {
                using (var contexto = new AlunoContext())
                {
                    contexto.Carros.Add(carro);
                    contexto.SaveChanges();
                    return View("IndexCarros");
                }

            }
            catch (Exception ex) { return Ok(ex.Message); }
        }





        [HttpGet("Carro/ReadCarros")]
        public ActionResult ReadCarros()
        {
            try
            {
                using (var contexto = new AlunoContext())
                {
                    var listCarros = contexto.Carros.ToList();
                    ViewBag.Carros = listCarros;
                    return View();
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }





        [HttpGet("/Carro/UpdateCarro")]
        public ActionResult UpdateCarro()
        {


            return View();

        }



        [HttpPost("/Carro/UpdateCarro")]
        public ActionResult UpdateCarro(Carro carro)
        {
            try
            {

                using (var contexto = new AlunoContext())
                {
                    var busca = contexto.Carros.Where(B => B.Id == carro.Id).FirstOrDefault();
                   

                    busca.documento = carro.documento;
                    busca.modelo = carro.modelo;
                    busca.placa = carro.placa;
                    
                    contexto.SaveChanges();
                    return View("IndexCarros");
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }

           
        }



        [HttpGet("/Carro/DeleteCarro")]
        public ActionResult DeleteCarro()
        {
            try
            {
                return View();
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }


        [HttpPost("/Carro/DeleteCarro")]
        public ActionResult DeleteCarro(Carro carro)
        {
            try
            {
                using (var contexto = new AlunoContext())
                {
                    var toDelete = contexto.Carros.Where(B => B.Id == carro.Id).Single();

                    contexto.Carros.Remove(toDelete);
                    contexto.SaveChanges();
                    Console.Write(carro.Id);
                    return View("IndexCarros");
                }
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }

    }
}
