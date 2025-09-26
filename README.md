Pratik – Code First Relation (User–Post)

Bu proje, Entity Framework Core (Code First) ile SQL Server LocalDB üzerinde basit bir 1→N ilişki kurar.

DbContext: PatikaSecondDbContext

Veritabanı: PatikaCodeFirstDb2

Tablolar: Users, Posts

İlişki: Bir User’ın birden çok Post’u olabilir; her Post bir User’a aittir.

1) Neler var?

Users

Id (int, PK, identity)

Username (string)

Email (string)

Posts

Id (int, PK, identity)

Title (string)

Content (string)

UserId (int, FK → Users.Id)

Not: İlişki Post tarafında UserId + User navigasyonu ile tanımlıdır.

2) Proje Yapısı (önerilen)
PatikaCodeFirst2/
 ├─ Models/
 │   ├─ User.cs
 │   └─ Post.cs
 ├─ Context/
 │   └─ PatikaSecondDbContext.cs
 ├─ Program.cs
 └─ Migrations/            # Add-Migration sonrası oluşur

3) Gerekli NuGet Paketleri

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Visual Studio: Projeye sağ tık → Manage NuGet Packages… → Browse bölümünden yükleyin.

4) Kurulum (Visual Studio – Console App)

Create a new project → Console App (.NET)

Project name (örnek): PatikaCodeFirst2

Folders: Models, Context oluşturun.

Dosyaları ekleyin (özet içerik):

Models/User.cs → Id, Username, Email

Models/Post.cs → Id, Title, Content, UserId, User

Context/PatikaSecondDbContext.cs →

DB adı: PatikaCodeFirstDb2

Tablo adları: Users, Posts

1→N ilişki: Post.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId)

Program.cs → Db’yi kısa test eden basit bir Count() yazısı

Build: Ctrl+Shift+B

5) Migration & Veritabanı Oluşturma

Tools → NuGet Package Manager → Package Manager Console (altta PM>):

Add-Migration InitialCreate -Context PatikaSecondDbContext
Update-Database -Verbose


İşlem bittiğinde SQL Server LocalDB’de PatikaCodeFirstDb2 ve tablolar Users/Posts oluşur.
