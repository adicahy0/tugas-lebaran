using System;

namespace SistemManajemenKaryawan
{
    public class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public Karyawan(string nama, string id, double gajiPokok)
        {
            this.nama = nama;
            this.id = id;
            this.gajiPokok = gajiPokok;
        }

        // Getter dan Setter
        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
        
        public void TampilkanInfo()
        {
            Console.WriteLine($"Nama: {nama}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Gaji Pokok: Rp {gajiPokok:N0}");
            Console.WriteLine($"Gaji Akhir: Rp {HitungGaji():N0}");
        }
    }

    public class KaryawanTetap : Karyawan
    {
        private const double BONUS_TETAP = 500000;

        public KaryawanTetap(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok)
        {
        }

        public override double HitungGaji()
        {
            return GajiPokok + BONUS_TETAP;
        }
    }
   public class KaryawanKontrak : Karyawan
    {
        private const double POTONGAN_KONTRAK = 200000;

        public KaryawanKontrak(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok)
        {
        }

        public override double HitungGaji()
        {
            return GajiPokok - POTONGAN_KONTRAK;
        }
    }

    public class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok)
        {
        }
        
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pilih jenis karyawan:");
            Console.WriteLine("1. Karyawan Tetap");
            Console.WriteLine("2. Karyawan Kontrak");
            Console.WriteLine("3. Karyawan Magang");
            Console.Write("Masukkan pilihan (1-3): ");
            int pilihan = int.Parse(Console.ReadLine());

            Console.Write("Masukkan nama karyawan: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan ID karyawan: ");
            string id = Console.ReadLine();

            Console.Write("Masukkan gaji pokok: ");
            double gajiPokok = double.Parse(Console.ReadLine());

            Karyawan karyawan = null;

            switch (pilihan)
            {
                case 1:
                    karyawan = new KaryawanTetap(nama, id, gajiPokok);
                    break;
                case 2:
                    karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                    break;
                case 3:
                    karyawan = new KaryawanMagang(nama, id, gajiPokok);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Membuat karyawan default.");
                    karyawan = new Karyawan(nama, id, gajiPokok);
                    break;
            }

            Console.WriteLine("\n=== INFORMASI KARYAWAN ===");
            karyawan.TampilkanInfo();

            if (karyawan is KaryawanTetap)
            {
                Console.WriteLine("Karyawan Tetap: Gaji Pokok + Bonus Tetap (Rp 500.000)");
            }
            else if (karyawan is KaryawanKontrak)
            {
                Console.WriteLine("Karyawan Kontrak: Gaji Pokok - Potongan Kontrak (Rp 200.000)");
            }
            else if (karyawan is KaryawanMagang)
            {
                Console.WriteLine("Karyawan Magang: Gaji Pokok (Tanpa bonus atau potongan)");
            }

            Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}