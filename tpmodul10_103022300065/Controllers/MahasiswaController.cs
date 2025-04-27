using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300065.Models;

using tpmodul10_103022300065.Models;
namespace tpmodul10_103022300065.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa {Nama = "Muhamamd Fauzan", NIM = "103022300065"},
            new Mahasiswa {Nama = "Rahmah Aisyah", NIM = "103022300014"},
            new Mahasiswa {Nama = "Dewanta Rahma Satria", NIM = "103022300071"},
            new Mahasiswa {Nama = "Dhea Noor Septianiz", NIM = "103022300072"},
            new Mahasiswa {Nama = "Dina Salsabila", NIM = "103022300114"},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return Ok(daftarMahasiswa);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }
            return Ok(daftarMahasiswa[index]);
        }

        [HttpPost]
        public ActionResult<Mahasiswa> PostMahasiswa(Mahasiswa mahasiswa)
        {
            daftarMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = daftarMahasiswa.Count - 1 }, mahasiswa);
        }

        [HttpDelete]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan untuk dihapus");
            }

            daftarMahasiswa.RemoveAt(index);
            return NoContent();
        }
    }
}
