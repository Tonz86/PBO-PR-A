using System;

namespace ManajemenKaryawan
{
    // Kelas Karyawan sebagai kelas parent
    public class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        // Constructor
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

        // Metode Hitung Gaji yang akan di override
        public virtual double HitungGaji()
        {
            throw new NotImplementedException();
        }
    }

    // Kelas KaryawanTetap
    public class KaryawanTetap : Karyawan
    {
        public KaryawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            double bonusTetap = 500000;
            return GajiPokok + bonusTetap;
        }
    }

    // Kelas KaryawanKontrak
    public class KaryawanKontrak : Karyawan
    {
        public KaryawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            double potonganKontrak = 200000;
            return GajiPokok - potonganKontrak;
        }
    }

    // Kelas KaryawanMagang
    public class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok; // Tidak ada bonus atau potongan
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
            string jenisKaryawan = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Masukkan nama karyawan: ");
            string nama = Console.ReadLine().Trim();

            Console.WriteLine("Masukkan ID karyawan: ");
            string idKaryawan = Console.ReadLine().Trim();

            Console.WriteLine("Masukkan gaji pokok: ");
            double gajiPokok = Convert.ToDouble(Console.ReadLine().Trim());

            Karyawan karyawan = null;

            switch (jenisKaryawan)
            {
                case "tetap":
                    karyawan = new KaryawanTetap(nama, idKaryawan, gajiPokok);
                    break;
                case "kontrak":
                    karyawan = new KaryawanKontrak(nama, idKaryawan, gajiPokok);
                    break;
                case "magang":
                    karyawan = new KaryawanMagang(nama, idKaryawan, gajiPokok);
                    break;
                default:
                    Console.WriteLine("Jenis karyawan tidak valid.");
                    return;
            }

            double gajiAkhir = karyawan.HitungGaji();
            Console.WriteLine($"Gaji akhir karyawan {karyawan.Nama} (ID: {karyawan.ID}): {gajiAkhir}");
        }
    }
}