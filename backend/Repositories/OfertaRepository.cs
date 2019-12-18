using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories {
    public class OfertaRepository : IOferta {
        public async Task<Oferta> Alterar (Oferta oferta) {
            using (fastradeContext _contexto = new fastradeContext ()) {
                _contexto.Entry (oferta).State = EntityState.Modified;
                await _contexto.SaveChangesAsync ();
            }
            return oferta;

        }

        public async Task<Oferta> BuscarPorID (int id) {
            using (fastradeContext _contexto = new fastradeContext ()) {

                return await _contexto.Oferta.Include ("IdUsuarioNavigation").Include("IdProdutoNavigation.IdCatProdutoNavigation").FirstOrDefaultAsync (e => e.IdOferta == id);

            }
        }

        public async Task<Oferta> Excluir (Oferta oferta) {
            using (fastradeContext _contexto = new fastradeContext ()) {
                _contexto.Oferta.Remove (oferta);
                await _contexto.SaveChangesAsync ();
                return oferta;
            }

        }

        public async Task<List<Oferta>> Listar () {
            using (fastradeContext _contexto = new fastradeContext ()) {
                return await _contexto.Oferta.Include("IdUsuarioNavigation").Include("IdProdutoNavigation.IdCatProdutoNavigation").ToListAsync();
            }
        }

        public async Task<Oferta> Salvar (Oferta oferta) {
            using (fastradeContext _contexto = new fastradeContext ()) {
                await _contexto.AddAsync (oferta);
                await _contexto.SaveChangesAsync ();
                return oferta;
            }
        }

        

		public  List<Oferta> FiltroCategoria(string filtro)
		{
			 using (fastradeContext _contexto = new fastradeContext ()) {
             List<Oferta> oferta = _contexto.Oferta.Include ("IdProdutoNavigation.IdCatProdutoNavigation").Where (o => o.IdProdutoNavigation.IdCatProdutoNavigation.Tipo.Contains (filtro)).ToList (); 
                    return oferta;
        }
	}
    }
}