# Câu hỏi lý thuyết C#

## Câu 1: Value Types và Reference Types

### Value Types – Kiểu giá trị

Value Type lưu **trực tiếp giá trị của biến**. Khi sao chép một biến Value Type sang biến khác thì hai biến có hai vùng giá trị riêng biệt.

Một số Value Type: `int`, `double`, `float`, `bool`, `struct`.

```csharp
int a = 10;
int b = a;

b = 20;

Console.WriteLine(a); // 10
Console.WriteLine(b); // 20
```

Khi thay đổi `b`, giá trị của `a` không thay đổi.

### Reference Types – Kiểu tham chiếu

Reference Type lưu **tham chiếu đến đối tượng**. Đối tượng thường được lưu trên Heap, còn biến tham chiếu giữ thông tin để truy cập đến đối tượng đó.

Một số Reference Type: `class`, `array`, `string`, `object`.

```csharp
class Student
{
    public string Name;
}

Student s1 = new Student();
s1.Name = "An";

Student s2 = s1;
s2.Name = "Nam";

Console.WriteLine(s1.Name); // Nam
```

` s1` và `s2` cùng tham chiếu đến một đối tượng nên thay đổi thông qua `s2` cũng làm thay đổi giá trị mà `s1` nhìn thấy.

> **Tóm lại:** Value Type sao chép **giá trị**, Reference Type sao chép **tham chiếu**.

---

## Câu 2: `init` và `set`

### `set`

`set` cho phép thay đổi giá trị thuộc tính sau khi đối tượng đã được tạo.

```csharp
class Student
{
    public string Name { get; set; }
}

Student sv = new Student();

sv.Name = "An";
sv.Name = "Nam";
```

`Name` có thể được thay đổi nhiều lần.

### `init`

`init` chỉ cho phép gán giá trị khi khởi tạo đối tượng.

```csharp
class Student
{
    public string Name { get; init; }
}

Student sv = new Student
{
    Name = "An"
};
```

Sau khi khởi tạo, không thể gán lại:

```csharp
// sv.Name = "Nam"; // Lỗi
```

### Trường hợp sử dụng

`init` phù hợp với những thuộc tính cần được thiết lập một lần và không muốn thay đổi sau khi tạo đối tượng.

Ví dụ:

```csharp
class Product
{
    public string MaSP { get; init; }
    public string TenSP { get; init; }
    public double Gia { get; init; }
}
```

> **Tóm lại:** `set` có thể thay đổi sau khi khởi tạo, còn `init` chỉ gán được trong quá trình khởi tạo.

---

## Câu 3: `virtual` và `override`

### `virtual`

`virtual` được khai báo ở **lớp cha**, cho phép lớp con ghi đè phương thức.

```csharp
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal sound");
    }
}
```

### `override`

`override` được khai báo ở **lớp con**, dùng để ghi đè phương thức `virtual` của lớp cha.

```csharp
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Gau gau");
    }
}
```

Ví dụ đa hình:

```csharp
Animal a = new Dog();

a.Sound();
```

Kết quả:

```text
Gau gau
```

Mặc dù biến có kiểu `Animal`, đối tượng thực tế là `Dog`, nên phương thức của `Dog` được thực hiện.

> **Tóm lại:** `virtual` → lớp cha cho phép ghi đè.  
> `override` → lớp con thực hiện ghi đè.

---

## Câu 4: Tại sao `static` không truy xuất thông qua Object?

`static` là thành phần **thuộc về Class**, không thuộc về từng Object.

Ví dụ:

```csharp
class Student
{
    public static string School = "EPU";
}
```

Truy cập bằng tên Class:

```csharp
Console.WriteLine(Student.School);
```

Không cần tạo Object bằng `new`.

### Thành phần thông thường

```csharp
class Student
{
    public string Name;
}

Student sv1 = new Student();
Student sv2 = new Student();

sv1.Name = "An";
sv2.Name = "Nam";
```

Mỗi Object có một `Name` riêng.

### Thành phần `static`

```csharp
class Student
{
    public static string School;
}

Student.School = "EPU";
```

`School` được dùng chung cho tất cả Object của lớp `Student`.

> **Tóm lại:** `static` thuộc về **Class**, vì vậy phải truy cập thông qua tên Class thay vì Object Instance.

---

## Tổng kết

1. Value Type: Lưu trực tiếp giá trị
2. Reference Type: Lưu tham chiếu đến đối tượng
3. Set: Có thể thay đổi giá trị sau khi khởi tạo
4. Init: Chỉ gán giá trị khi khởi tạo
5. Virtual: Cho phép lớp con ghi đè
6. Override: Lớp con thực hiện ghi đè
7. Static: Thành phần thuộc về Class, dùng chung cho các Object
