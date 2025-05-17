using System.Collections.Generic;
using System;



using System;
using System.Collections.Generic;

namespace SistemDataKampus
{
    
    class DataMhs
    {
        public string Nim { get; set; }
        public string Nama { get; set; }
        public string Prodi { get; set; }

        public DataMhs(string nim, string nama, string prodi)
        {
            Nim = nim;
            Nama = nama;
            Prodi = prodi;
        }

        public void Info()
        {
            Console.WriteLine($"NIM: {Nim}, Nama: {Nama}, Prodi: {Prodi}");
        }
    }

    
    class PengelolaMhs
    {
        private List<DataMhs> daftarMhs = new List<DataMhs>();

        public void TambahMhs()
        {
            Console.Write("Masukkan NIM: ");
            string nim = Console.ReadLine();

            
            if (daftarMhs.Exists(m => m.Nim == nim))
            {
                Console.WriteLine("NIM sudah terdaftar!");
                return;
            }

            Console.Write("Masukkan Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan Prodi: ");
            string prodi = Console.ReadLine();

            daftarMhs.Add(new DataMhs(nim, nama, prodi));
            Console.WriteLine("Data mahasiswa ditambahkan!");
        }

        public void LihatSemua()
        {
            if (daftarMhs.Count == 0)
            {
                Console.WriteLine("Belum ada data mahasiswa.");
                return;
            }

            Console.WriteLine("== Daftar Mahasiswa ==");
            foreach (var mhs in daftarMhs)
            {
                mhs.Info();
            }
        }

        public void EditMhs()
        {
            Console.Write("Masukkan NIM yang mau diedit: ");
            string nim = Console.ReadLine();

            var target = daftarMhs.Find(m => m.Nim == nim);
            if (target == null)
            {
                Console.WriteLine("Mahasiswa tidak ditemukan.");
                return;
            }

            Console.Write("Nama baru: ");
            target.Nama = Console.ReadLine();
            Console.Write("Prodi baru: ");
            target.Prodi = Console.ReadLine();

            Console.WriteLine("Data berhasil diperbarui!");
        }

        public void HapusMhs()
        {
            Console.Write("Masukkan NIM yang akan dihapus: ");
            string nim = Console.ReadLine();

            var found = daftarMhs.Find(m => m.Nim == nim);
            if (found == null)
            {
                Console.WriteLine("NIM tidak ditemukan.");
                return;
            }

            daftarMhs.Remove(found);
            Console.WriteLine("Data telah dihapus.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PengelolaMhs kelola = new PengelolaMhs();
            int pilihan = 0;

            do
            {
                Console.WriteLine("\n===== Menu Mahasiswa =====");
                Console.WriteLine("1. Tambah Mahasiswa");
                Console.WriteLine("2. Lihat Semua Mahasiswa");
                Console.WriteLine("3. Update Data Mahasiswa");
                Console.WriteLine("4. Hapus Mahasiswa");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih: ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid.");
                    continue;
                }

                switch (pilihan)
                {
                    case 1:
                        kelola.TambahMhs();
                        break;
                    case 2:
                        kelola.LihatSemua();
                        break;
                    case 3:
                        kelola.EditMhs();
                        break;
                    case 4:
                        kelola.HapusMhs();
                        break;
                    case 5:
                        Console.WriteLine("Keluar dari program.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

            } while (pilihan != 5);
        }
    }
}