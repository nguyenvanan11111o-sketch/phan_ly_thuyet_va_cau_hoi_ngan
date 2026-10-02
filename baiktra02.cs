using System;
using System.Collections.Generic;
using System.Linq;

abstract class PhuongTien
{
    private string _maPT = "";
    private string _tenHang = "";
    private int _namSanXuat;
    private decimal _giaGoc;

    
    public string MaPT
    {
        get
        {
            return _maPT;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _maPT = "PT000";
            }
            else
            {
                _maPT = value;
            }
        }
    }

    
    public string TenHang
    {
        get
        {
            return _tenHang;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Tên hãng không được để trống!");
            }

            _tenHang = value;
        }
    }

    
    public int NamSanXuat
    {
        get
        {
            return _namSanXuat;
        }
        set
        {
            int namHienTai = DateTime.Now.Year;

            if (value < 1900 || value > namHienTai)
            {
                throw new ArgumentException(
                    "Năm sản xuất phải từ 1900 đến " + namHienTai
                );
            }

            _namSanXuat = value;
        }
    }

    
    public decimal GiaGoc
    {
        get
        {
            return _giaGoc;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Giá gốc phải lớn hơn 0!"
                );
            }

            _giaGoc = value;
        }
    }

    
    public PhuongTien(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }

    // Abstract method
    public abstract decimal TinhGiaLanBanh();

    // Virtual method
    public virtual string GetInfo()
    {
        return "Mã PT: " + MaPT +
               " | Hãng: " + TenHang +
               " | Năm SX: " + NamSanXuat +
               " | Giá gốc: " + GiaGoc.ToString("N0") + " VNĐ";
    }
}


// ======================================================
// 2. CLASS OTO
// ======================================================

class OTo : PhuongTien
{
    private int _soChoNgoi;
    private double _dungTichDongCo;

    // Property SoChoNgoi
    public int SoChoNgoi
    {
        get
        {
            return _soChoNgoi;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Số chỗ ngồi phải lớn hơn 0!"
                );
            }

            _soChoNgoi = value;
        }
    }

    // Property DungTichDongCo
    public double DungTichDongCo
    {
        get
        {
            return _dungTichDongCo;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Dung tích động cơ phải lớn hơn 0!"
                );
            }

            _dungTichDongCo = value;
        }
    }

    // Constructor
    public OTo(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int soChoNgoi,
        double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    // Override TinhGiaLanBanh
    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
        {
            // Giá gốc + 12% lệ phí trước bạ + 30% TTĐB
            return GiaGoc + GiaGoc * 0.12m + GiaGoc * 0.30m;
        }
        else
        {
            // Giá gốc + 10% lệ phí trước bạ
            return GiaGoc + GiaGoc * 0.10m;
        }
    }

    // Override GetInfo
    public override string GetInfo()
    {
        return base.GetInfo() +
               " | Số chỗ: " + SoChoNgoi +
               " | Dung tích động cơ: " + DungTichDongCo + " cc";
    }
}


// ======================================================
// 3. CLASS XEMAY
// ======================================================

class XeMay : PhuongTien
{
    private int _dungTichXylanh;

    // Property DungTichXylanh
    public int DungTichXylanh
    {
        get
        {
            return _dungTichXylanh;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Dung tích xy-lanh phải lớn hơn 0!"
                );
            }

            _dungTichXylanh = value;
        }
    }

    // Constructor
    public XeMay(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        DungTichXylanh = dungTichXylanh;
    }

    // Override TinhGiaLanBanh
    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
        {
            // Giá gốc + 2%
            return GiaGoc + GiaGoc * 0.02m;
        }
        else
        {
            // Giá gốc + 5%
            return GiaGoc + GiaGoc * 0.05m;
        }
    }

    // Override GetInfo
    public override string GetInfo()
    {
        return base.GetInfo() +
               " | Dung tích xy-lanh: " +
               DungTichXylanh + " cc";
    }
}


// ======================================================
// 4. CLASS QUANLYPHUONGTIEN
// ======================================================


class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach;

    public QuanLyPhuongTien()
    {
        danhSach = new List<PhuongTien>();
    }

    // 1. Thêm phương tiện
    public void AddPhuongTien(PhuongTien pt)
    {
        danhSach.Add(pt);
    }

    // 2. Hiển thị toàn bộ
    public void DisplayAll()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sách phương tiện đang rỗng!");
            return;
        }

        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());

            Console.WriteLine(
                "Giá lăn bánh: " +
                pt.TinhGiaLanBanh().ToString("N0") +
                " VNĐ"
            );

            Console.WriteLine("--------------------------------");
        }
    }

    // 3. Tìm phương tiện có giá lăn bánh cao nhất
    public PhuongTien? FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
        {
            return null;
        }

        return danhSach
            .OrderByDescending(
                pt => pt.TinhGiaLanBanh()
            )
            .First();
    }

    // 4. Tìm theo tên hãng
    public List<PhuongTien> SearchByName(string keyword)
    {
        return danhSach
            .Where(
                pt => pt.TenHang.Contains(
                    keyword,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            .ToList();
    }
}

// ======================================================
// 5. PROGRAM
// ======================================================

class Program
{
    // =========================================
    // CHỨC NĂNG 1: THÊM PHƯƠNG TIỆN
    // =========================================

    static void ThemPhuongTien(QuanLyPhuongTien quanLy)
    {
        Console.WriteLine("\n===== THEM PHUONG TIEN =====");

        Console.Write("Nhập mã phương tiện: ");
        string ma = Console.ReadLine() ?? "";

        Console.Write("Nhập tên hãng: ");
        string tenHang = Console.ReadLine() ?? "";

        Console.Write("Nhập năm sản xuất: ");
        int nam = int.Parse(Console.ReadLine()!);

        Console.Write("Nhập giá gốc: ");
        decimal gia = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("\n1. Ô tô");
        Console.WriteLine("2. Xe máy");

        Console.Write("Chọn loại phương tiện: ");
        int loai = int.Parse(Console.ReadLine()!);

        if (loai == 1)
        {
            Console.Write("Nhập số chỗ ngồi: ");
            int soCho = int.Parse(Console.ReadLine()!);

            Console.Write("Nhập dung tích động cơ: ");
            double dungTich = double.Parse(Console.ReadLine()!);

            OTo oto = new OTo(
                ma,
                tenHang,
                nam,
                gia,
                soCho,
                dungTich
            );

            quanLy.AddPhuongTien(oto);

            Console.WriteLine("Đã thêm ô tô!");
        }
        else if (loai == 2)
        {
            Console.Write("Nhập dung tích xy-lanh: ");
            int xyLanh = int.Parse(Console.ReadLine()!);

            XeMay xeMay = new XeMay(
                ma,
                tenHang,
                nam,
                gia,
                xyLanh
            );

            quanLy.AddPhuongTien(xeMay);

            Console.WriteLine("Đã thêm xe máy!");
        }
        else
        {
            Console.WriteLine("Loại phương tiện không hợp lệ!");
        }
    }


    // =========================================
    // CHỨC NĂNG 2: HIỂN THỊ
    // =========================================

    static void HienThiDanhSach(QuanLyPhuongTien quanLy)
    {
        Console.WriteLine("\n===== DANH SACH PHUONG TIEN =====");

        quanLy.DisplayAll();
    }


    // =========================================
    // CHỨC NĂNG 3: TÌM GIÁ CAO NHẤT
    // =========================================

    static void TimGiaCaoNhat(QuanLyPhuongTien quanLy)
    {
        Console.WriteLine(
            "\n===== PHUONG TIEN CO GIA LAN BANH CAO NHAT ====="
        );

        PhuongTien? pt =
            quanLy.FindMaxGiaLanBanh();

        if (pt == null)
        {
            Console.WriteLine(
                "Danh sách phương tiện đang rỗng!"
            );

            return;
        }

        Console.WriteLine(pt.GetInfo());

        Console.WriteLine(
            "Giá lăn bánh: " +
            pt.TinhGiaLanBanh().ToString("N0") +
            " VNĐ"
        );
    }


    // =========================================
    // CHỨC NĂNG 4: TÌM THEO TÊN HÃNG
    // =========================================

    static void TimTheoTenHang(QuanLyPhuongTien quanLy)
    {
        Console.WriteLine("\n===== TIM THEO TEN HANG =====");

        Console.Write("Nhập tên hãng cần tìm: ");
        string keyword = Console.ReadLine() ?? "";

        List<PhuongTien> ketQua =
            quanLy.SearchByName(keyword);

        if (ketQua.Count == 0)
        {
            Console.WriteLine(
                "Không tìm thấy phương tiện!"
            );

            return;
        }

        Console.WriteLine("\nKết quả tìm kiếm:");

        foreach (PhuongTien pt in ketQua)
        {
            Console.WriteLine(pt.GetInfo());

            Console.WriteLine(
                "Giá lăn bánh: " +
                pt.TinhGiaLanBanh().ToString("N0") +
                " VNĐ"
            );

            Console.WriteLine("--------------------------------");
        }
    }


    // =========================================
    // MAIN
    // =========================================

    static void Main()
    {
        QuanLyPhuongTien quanLy =
            new QuanLyPhuongTien();

        while (true)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   QUAN LY PHUONG TIEN");
            Console.WriteLine("==============================");

            Console.WriteLine("1. Thêm phương tiện");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm giá lăn bánh cao nhất");
            Console.WriteLine("4. Tìm theo tên hãng");
            Console.WriteLine("0. Thoát");

            Console.WriteLine("==============================");

            Console.Write("Nhập lựa chọn: ");

            int choice = int.Parse(
                Console.ReadLine()!
            );

            try
            {
                switch (choice)
                {
                    case 1:
                        ThemPhuongTien(quanLy);
                        break;

                    case 2:
                        HienThiDanhSach(quanLy);
                        break;

                    case 3:
                        TimGiaCaoNhat(quanLy);
                        break;

                    case 4:
                        TimTheoTenHang(quanLy);
                        break;

                    case 0:
                        Console.WriteLine(
                            "Đã thoát chương trình!"
                        );
                        return;

                    default:
                        Console.WriteLine(
                            "Lựa chọn không hợp lệ!"
                        );
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    "Lỗi: " + ex.Message
                );
            }
        }
    }
}