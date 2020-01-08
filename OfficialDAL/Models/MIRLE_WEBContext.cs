using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficialDAL.Models
{
    public partial class MIRLE_WEBContext : DbContext
    {
        public MIRLE_WEBContext()
        {
        }

        public MIRLE_WEBContext(DbContextOptions<MIRLE_WEBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AdminGroup> AdminGroup { get; set; }
        public virtual DbSet<AdminGroupNew> AdminGroupNew { get; set; }
        public virtual DbSet<AdminNew> AdminNew { get; set; }
        public virtual DbSet<BotLog> BotLog { get; set; }
        public virtual DbSet<CarouselNew> CarouselNew { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyNew> CompanyNew { get; set; }
        public virtual DbSet<FuntionNew> FuntionNew { get; set; }
        public virtual DbSet<Ibg> Ibg { get; set; }
        public virtual DbSet<IbgKind> IbgKind { get; set; }
        public virtual DbSet<IbgKindNew> IbgKindNew { get; set; }
        public virtual DbSet<IbgNew> IbgNew { get; set; }
        public virtual DbSet<IcContact> IcContact { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemNew> ItemNew { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsKind> NewsKind { get; set; }
        public virtual DbSet<NewsKindNew> NewsKindNew { get; set; }
        public virtual DbSet<NewsMappingTable> NewsMappingTable { get; set; }
        public virtual DbSet<NewsNew> NewsNew { get; set; }
        public virtual DbSet<Ph001v01> Ph001v01 { get; set; }
        public virtual DbSet<Ph001v02> Ph001v02 { get; set; }
        public virtual DbSet<PostCity> PostCity { get; set; }
        public virtual DbSet<PostCityNew> PostCityNew { get; set; }
        public virtual DbSet<PostNumber> PostNumber { get; set; }
        public virtual DbSet<PostNumberNew> PostNumberNew { get; set; }
        public virtual DbSet<ProKind> ProKind { get; set; }
        public virtual DbSet<ProKindNew> ProKindNew { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductNew> ProductNew { get; set; }
        public virtual DbSet<Re002f01v00> Re002f01v00 { get; set; }
        public virtual DbSet<Re002f01v01> Re002f01v01 { get; set; }
        public virtual DbSet<Solution> Solution { get; set; }
        public virtual DbSet<SolutionKind> SolutionKind { get; set; }
        public virtual DbSet<SolutionKindNew> SolutionKindNew { get; set; }
        public virtual DbSet<SolutionNew> SolutionNew { get; set; }
        public virtual DbSet<SolutionNewsRel> SolutionNewsRel { get; set; }
        public virtual DbSet<VideoNew> VideoNew { get; set; }
        public virtual DbSet<WebCounter> WebCounter { get; set; }
        public virtual DbSet<WebCounterNew> WebCounterNew { get; set; }
        public virtual DbSet<Webv01> Webv01 { get; set; }
        public virtual DbSet<Webv02> Webv02 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.3.180;Database=MIRLE_WEB;User ID=sa;Password=Password!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("admin");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(10);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(10);

                entity.Property(e => e.LoginCode)
                    .HasColumnName("login_code")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LoginIp)
                    .HasColumnName("login_ip")
                    .HasMaxLength(50);

                entity.Property(e => e.LoginTime)
                    .HasColumnName("login_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Online).HasColumnName("online");

                entity.Property(e => e.Phone1)
                    .HasColumnName("phone1")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .HasColumnName("phone2")
                    .HasMaxLength(50);

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasMaxLength(10);

                entity.Property(e => e.RegTime)
                    .HasColumnName("reg_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(2);

                entity.Property(e => e.UId)
                    .HasColumnName("u_id")
                    .HasMaxLength(50);

                entity.Property(e => e.UName)
                    .HasColumnName("u_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UPassword)
                    .HasColumnName("u_password")
                    .HasMaxLength(50);

                entity.Property(e => e.Uid1)
                    .HasColumnName("uid")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AdminGroup>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("admin_group");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Demo)
                    .HasColumnName("demo")
                    .HasMaxLength(100);

                entity.Property(e => e.GName)
                    .HasColumnName("g_name")
                    .HasMaxLength(3);

                entity.Property(e => e.Items)
                    .HasColumnName("items")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AdminGroupNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("admin_group_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo)
                    .HasColumnName("demo")
                    .HasMaxLength(100);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GName)
                    .HasColumnName("g_name")
                    .HasMaxLength(3);

                entity.Property(e => e.Items)
                    .HasColumnName("items")
                    .HasMaxLength(255);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdminNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("admin_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(10);

                entity.Property(e => e.LoginCode)
                    .HasColumnName("login_code")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LoginIp)
                    .HasColumnName("login_ip")
                    .HasMaxLength(50);

                entity.Property(e => e.LoginTime)
                    .HasColumnName("login_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Online).HasColumnName("online");

                entity.Property(e => e.Phone1)
                    .HasColumnName("phone1")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .HasColumnName("phone2")
                    .HasMaxLength(50);

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasMaxLength(10);

                entity.Property(e => e.RegTime)
                    .HasColumnName("reg_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(2);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UId)
                    .HasColumnName("u_id")
                    .HasMaxLength(50);

                entity.Property(e => e.UName)
                    .HasColumnName("u_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UPassword)
                    .HasColumnName("u_password")
                    .HasMaxLength(50);

                entity.Property(e => e.Uid1)
                    .HasColumnName("uid")
                    .HasMaxLength(20);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BotLog>(entity =>
            {
                entity.ToTable("bot_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Request).HasColumnName("request");

                entity.Property(e => e.Response).HasColumnName("response");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");
            });

            modelBuilder.Entity<CarouselNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("carousel_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtExpire)
                    .HasColumnName("dt_expire")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(year,(10),getdate()))");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(1024);

                entity.Property(e => e.PopupImg)
                    .HasColumnName("popup_img")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PopupLink)
                    .HasColumnName("popup_link")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Slogan).HasColumnName("slogan");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.StatVoid)
                    .HasColumnName("stat_void")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UrlType)
                    .HasColumnName("url_type")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.YoutubeCode)
                    .HasColumnName("youtube_code")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("company");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.ComMail)
                    .HasColumnName("com_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.ComName)
                    .HasColumnName("com_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LogClass).HasColumnName("log_class");

                entity.Property(e => e.LogMenu)
                    .HasColumnName("log_menu")
                    .HasMaxLength(20);

                entity.Property(e => e.Menu).HasColumnName("menu");

                entity.Property(e => e.PicUrl)
                    .HasColumnName("pic_url")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("company_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.ComMail)
                    .HasColumnName("com_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.ComName)
                    .HasColumnName("com_name")
                    .HasMaxLength(20);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogClass).HasColumnName("log_class");

                entity.Property(e => e.LogMenu)
                    .HasColumnName("log_menu")
                    .HasMaxLength(20);

                entity.Property(e => e.Menu).HasColumnName("menu");

                entity.Property(e => e.PicUrl)
                    .HasColumnName("pic_url")
                    .HasMaxLength(50);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FuntionNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("funtion_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Funname)
                    .HasColumnName("funname")
                    .HasMaxLength(1024);

                entity.Property(e => e.GGame)
                    .HasColumnName("g_game")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ibg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBG");

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctdate)
                    .HasColumnName("CTDATE")
                    .HasMaxLength(50);

                entity.Property(e => e.Department)
                    .HasColumnName("DEPARTMENT")
                    .HasMaxLength(50);

                entity.Property(e => e.Eat)
                    .HasColumnName("EAT")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Meat)
                    .HasColumnName("MEAT")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobil)
                    .HasColumnName("MOBIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Office)
                    .HasColumnName("OFFICE")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(1024);

                entity.Property(e => e.Site)
                    .HasColumnName("SITE")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IbgKind>(entity =>
            {
                entity.HasKey(e => e.SiteCode);

                entity.ToTable("IBG_KIND");

                entity.Property(e => e.SiteCode)
                    .HasColumnName("site_code")
                    .HasMaxLength(50);

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<IbgKindNew>(entity =>
            {
                entity.HasKey(e => e.SiteCode);

                entity.ToTable("IBG_KIND_new");

                entity.Property(e => e.SiteCode)
                    .HasColumnName("site_code")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(1024);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IbgNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBG_new");

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ctdate)
                    .HasColumnName("CTDATE")
                    .HasMaxLength(50);

                entity.Property(e => e.Department)
                    .HasColumnName("DEPARTMENT")
                    .HasMaxLength(50);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eat)
                    .HasColumnName("EAT")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Meat)
                    .HasColumnName("MEAT")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobil)
                    .HasColumnName("MOBIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Office)
                    .HasColumnName("OFFICE")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(1024);

                entity.Property(e => e.Site)
                    .HasColumnName("SITE")
                    .HasMaxLength(50);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IcContact>(entity =>
            {
                entity.ToTable("ic_contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.StatUpdate).HasColumnName("stat_update");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("item");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Demo)
                    .HasColumnName("demo")
                    .HasMaxLength(255);

                entity.Property(e => e.Other)
                    .HasColumnName("other")
                    .HasMaxLength(255);

                entity.Property(e => e.OtherUrl)
                    .HasColumnName("other_url")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SId)
                    .HasColumnName("s_id")
                    .HasMaxLength(10);

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasMaxLength(2);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ItemNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("item_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo)
                    .HasColumnName("demo")
                    .HasMaxLength(255);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Other)
                    .HasColumnName("other")
                    .HasMaxLength(255);

                entity.Property(e => e.OtherUrl)
                    .HasColumnName("other_url")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SId)
                    .HasColumnName("s_id")
                    .HasMaxLength(10);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasMaxLength(2);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("news");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10);

                entity.Property(e => e.Person)
                    .HasColumnName("person")
                    .HasMaxLength(15);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(100);

                entity.Property(e => e.Uptime)
                    .HasColumnName("uptime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(111)))");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<NewsKind>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("news_kind");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(100);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NewsKindNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("news_kind_new");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(100);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Range).HasColumnName("range");

                entity.Property(e => e.Root).HasColumnName("root");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewsMappingTable>(entity =>
            {
                entity.ToTable("news_mapping_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdNew).HasColumnName("id_new");

                entity.Property(e => e.IdOld).HasColumnName("id_old");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");
            });

            modelBuilder.Entity<NewsNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("news_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(30);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10);

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.Person)
                    .HasColumnName("person")
                    .HasMaxLength(15);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Search).HasColumnName("search");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Uptime)
                    .HasColumnName("uptime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(111)))");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<Ph001v01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PH001V01");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind1)
                    .HasColumnName("kind1")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Num1).HasColumnName("num1");

                entity.Property(e => e.Root).HasColumnName("root");
            });

            modelBuilder.Entity<Ph001v02>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PH001V02");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind1)
                    .HasColumnName("kind1")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Num1).HasColumnName("num1");

                entity.Property(e => e.Root).HasColumnName("root");
            });

            modelBuilder.Entity<PostCity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<PostCityNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostCity_new");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostNumber>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PostNumber1)
                    .HasColumnName("PostNumber")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PostNumberNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostNumber_new");

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PostNumber).HasMaxLength(255);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProKind>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pro_kind");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("link_url")
                    .HasMaxLength(225);

                entity.Property(e => e.LinkUrl2)
                    .HasColumnName("link_url2")
                    .HasMaxLength(225);

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Words).HasColumnName("words");
            });

            modelBuilder.Entity<ProKindNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("pro_kind_new");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fontawsome)
                    .HasColumnName("fontawsome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ispresent)
                    .HasColumnName("ispresent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Itemclass)
                    .HasColumnName("itemclass")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("link_url")
                    .HasMaxLength(225);

                entity.Property(e => e.LinkUrl2)
                    .HasColumnName("link_url2")
                    .HasMaxLength(225);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Words).HasColumnName("words");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("product");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.BuyKind1)
                    .HasColumnName("buy_kind1")
                    .HasMaxLength(255);

                entity.Property(e => e.BuyKind2)
                    .HasColumnName("buy_kind2")
                    .HasMaxLength(255);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Keyword).HasColumnName("keyword");

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("link_url")
                    .HasMaxLength(255);

                entity.Property(e => e.MailCount)
                    .HasColumnName("mail_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Person)
                    .HasColumnName("person")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProBonus)
                    .HasColumnName("pro_bonus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProCount)
                    .HasColumnName("pro_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProKind)
                    .HasColumnName("pro_kind")
                    .HasMaxLength(20);

                entity.Property(e => e.ProKind2)
                    .HasColumnName("pro_kind2")
                    .HasMaxLength(10);

                entity.Property(e => e.ProKind3)
                    .HasColumnName("pro_kind3")
                    .HasMaxLength(10);

                entity.Property(e => e.ProLang)
                    .HasColumnName("pro_lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProNum)
                    .HasColumnName("pro_num")
                    .HasMaxLength(50);

                entity.Property(e => e.ProOther)
                    .HasColumnName("pro_other")
                    .HasMaxLength(255);

                entity.Property(e => e.ProQty)
                    .HasColumnName("pro_qty")
                    .HasMaxLength(8);

                entity.Property(e => e.ProQtyChk).HasColumnName("pro_qty_chk");

                entity.Property(e => e.ProSell)
                    .HasColumnName("pro_sell")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specification)
                    .HasColumnName("specification")
                    .HasMaxLength(255);

                entity.Property(e => e.Words).HasColumnName("words");

                entity.Property(e => e.Words2).HasColumnName("words2");
            });

            modelBuilder.Entity<ProductNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("product_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.BuyKind1)
                    .HasColumnName("buy_kind1")
                    .HasMaxLength(255);

                entity.Property(e => e.BuyKind2)
                    .HasColumnName("buy_kind2")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(50);

                entity.Property(e => e.Desc).HasColumnName("desc");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Keyword).HasColumnName("keyword");

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("link_url")
                    .HasMaxLength(255);

                entity.Property(e => e.MailCount)
                    .HasColumnName("mail_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Person)
                    .HasColumnName("person")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProBonus)
                    .HasColumnName("pro_bonus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProCount)
                    .HasColumnName("pro_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProKind)
                    .HasColumnName("pro_kind")
                    .HasMaxLength(20);

                entity.Property(e => e.ProKind2)
                    .HasColumnName("pro_kind2")
                    .HasMaxLength(10);

                entity.Property(e => e.ProKind3)
                    .HasColumnName("pro_kind3")
                    .HasMaxLength(10);

                entity.Property(e => e.ProLang)
                    .HasColumnName("pro_lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProNum)
                    .HasColumnName("pro_num")
                    .HasMaxLength(50);

                entity.Property(e => e.ProOther)
                    .HasColumnName("pro_other")
                    .HasMaxLength(255);

                entity.Property(e => e.ProQty)
                    .HasColumnName("pro_qty")
                    .HasMaxLength(8);

                entity.Property(e => e.ProQtyChk).HasColumnName("pro_qty_chk");

                entity.Property(e => e.ProSell)
                    .HasColumnName("pro_sell")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Search).HasColumnName("search");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specification)
                    .HasColumnName("specification")
                    .HasMaxLength(255);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Words).HasColumnName("words");

                entity.Property(e => e.Words2).HasColumnName("words2");
            });

            modelBuilder.Entity<Re002f01v00>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RE002F01V00");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Root).HasColumnName("root");
            });

            modelBuilder.Entity<Re002f01v01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RE002F01V01");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind2)
                    .HasColumnName("kind2")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Nump).HasColumnName("nump");
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.BuyKind1)
                    .HasColumnName("buy_kind1")
                    .HasMaxLength(255);

                entity.Property(e => e.BuyKind2)
                    .HasColumnName("buy_kind2")
                    .HasMaxLength(255);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.MailCount)
                    .HasColumnName("mail_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProBonus)
                    .HasColumnName("pro_bonus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProCount)
                    .HasColumnName("pro_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProKind)
                    .HasColumnName("pro_kind")
                    .HasMaxLength(20);

                entity.Property(e => e.ProKind2)
                    .HasColumnName("pro_kind2")
                    .HasMaxLength(10);

                entity.Property(e => e.ProKind3)
                    .HasColumnName("pro_kind3")
                    .HasMaxLength(10);

                entity.Property(e => e.ProLang)
                    .HasColumnName("pro_lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProNews)
                    .HasColumnName("pro_news")
                    .HasMaxLength(255);

                entity.Property(e => e.ProNum)
                    .HasColumnName("pro_num")
                    .HasMaxLength(50);

                entity.Property(e => e.ProOther)
                    .HasColumnName("pro_other")
                    .HasMaxLength(255);

                entity.Property(e => e.ProQty)
                    .HasColumnName("pro_qty")
                    .HasMaxLength(8);

                entity.Property(e => e.ProQtyChk).HasColumnName("pro_qty_chk");

                entity.Property(e => e.ProSell)
                    .HasColumnName("pro_sell")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specification)
                    .HasColumnName("specification")
                    .HasMaxLength(255);

                entity.Property(e => e.Words).HasColumnName("words");

                entity.Property(e => e.Words2).HasColumnName("words2");
            });

            modelBuilder.Entity<SolutionKind>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Solution_kind");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SolutionKindNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("Solution_kind_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2).HasColumnName("pic2");

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SolutionNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("Solution_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.BuyKind1)
                    .HasColumnName("buy_kind1")
                    .HasMaxLength(255);

                entity.Property(e => e.BuyKind2)
                    .HasColumnName("buy_kind2")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Desc).HasColumnName("desc");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.LangType).HasColumnName("lang_type");

                entity.Property(e => e.MailCount)
                    .HasColumnName("mail_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProBonus)
                    .HasColumnName("pro_bonus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProCount)
                    .HasColumnName("pro_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProKind)
                    .HasColumnName("pro_kind")
                    .HasMaxLength(20);

                entity.Property(e => e.ProKind2)
                    .HasColumnName("pro_kind2")
                    .HasMaxLength(10);

                entity.Property(e => e.ProKind3)
                    .HasColumnName("pro_kind3")
                    .HasMaxLength(10);

                entity.Property(e => e.ProLang)
                    .HasColumnName("pro_lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProNews)
                    .HasColumnName("pro_news")
                    .HasMaxLength(255);

                entity.Property(e => e.ProNum)
                    .HasColumnName("pro_num")
                    .HasMaxLength(50);

                entity.Property(e => e.ProOther)
                    .HasColumnName("pro_other")
                    .HasMaxLength(255);

                entity.Property(e => e.ProQty)
                    .HasColumnName("pro_qty")
                    .HasMaxLength(8);

                entity.Property(e => e.ProQtyChk).HasColumnName("pro_qty_chk");

                entity.Property(e => e.ProSell)
                    .HasColumnName("pro_sell")
                    .HasMaxLength(10);

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Search).HasColumnName("search");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specification)
                    .HasColumnName("specification")
                    .HasMaxLength(255);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Words).HasColumnName("words");

                entity.Property(e => e.Words2).HasColumnName("words2");
            });

            modelBuilder.Entity<SolutionNewsRel>(entity =>
            {
                entity.ToTable("Solution_news_rel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdNews).HasColumnName("id_news");

                entity.Property(e => e.IdSolution).HasColumnName("id_solution");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VideoNew>(entity =>
            {
                entity.HasKey(e => e.Num);

                entity.ToTable("video_new");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Demo)
                    .HasColumnName("demo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Uptime)
                    .HasColumnName("uptime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<WebCounter>(entity =>
            {
                entity.ToTable("web_counter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(111)))");

                entity.Property(e => e.Hr0)
                    .HasColumnName("HR0")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr1)
                    .HasColumnName("HR1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr10)
                    .HasColumnName("HR10")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr11)
                    .HasColumnName("HR11")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr12)
                    .HasColumnName("HR12")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr13)
                    .HasColumnName("HR13")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr14)
                    .HasColumnName("HR14")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr15)
                    .HasColumnName("HR15")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr16)
                    .HasColumnName("HR16")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr17)
                    .HasColumnName("HR17")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr18)
                    .HasColumnName("HR18")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr19)
                    .HasColumnName("HR19")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr2)
                    .HasColumnName("HR2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr20)
                    .HasColumnName("HR20")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr21)
                    .HasColumnName("HR21")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr22)
                    .HasColumnName("HR22")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr23)
                    .HasColumnName("HR23")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr3)
                    .HasColumnName("HR3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr4)
                    .HasColumnName("HR4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr5)
                    .HasColumnName("HR5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr6)
                    .HasColumnName("HR6")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr7)
                    .HasColumnName("HR7")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr8)
                    .HasColumnName("HR8")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr9)
                    .HasColumnName("HR9")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastIp)
                    .HasColumnName("LastIP")
                    .HasMaxLength(16);

                entity.Property(e => e.Today).HasDefaultValueSql("((0))");

                entity.Property(e => e.Total).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<WebCounterNew>(entity =>
            {
                entity.ToTable("web_counter_new");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(111)))");

                entity.Property(e => e.DtCreate)
                    .HasColumnName("dt_create")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtUpdate)
                    .HasColumnName("dt_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.Hr0)
                    .HasColumnName("HR0")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr1)
                    .HasColumnName("HR1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr10)
                    .HasColumnName("HR10")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr11)
                    .HasColumnName("HR11")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr12)
                    .HasColumnName("HR12")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr13)
                    .HasColumnName("HR13")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr14)
                    .HasColumnName("HR14")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr15)
                    .HasColumnName("HR15")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr16)
                    .HasColumnName("HR16")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr17)
                    .HasColumnName("HR17")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr18)
                    .HasColumnName("HR18")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr19)
                    .HasColumnName("HR19")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr2)
                    .HasColumnName("HR2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr20)
                    .HasColumnName("HR20")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr21)
                    .HasColumnName("HR21")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr22)
                    .HasColumnName("HR22")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr23)
                    .HasColumnName("HR23")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr3)
                    .HasColumnName("HR3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr4)
                    .HasColumnName("HR4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr5)
                    .HasColumnName("HR5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr6)
                    .HasColumnName("HR6")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr7)
                    .HasColumnName("HR7")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr8)
                    .HasColumnName("HR8")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hr9)
                    .HasColumnName("HR9")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastIp)
                    .HasColumnName("LastIP")
                    .HasMaxLength(16);

                entity.Property(e => e.StatVoid).HasColumnName("stat_void");

                entity.Property(e => e.Today).HasDefaultValueSql("((0))");

                entity.Property(e => e.Total).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Webv01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("webv01");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(311);

                entity.Property(e => e.Link2)
                    .HasColumnName("link2")
                    .HasMaxLength(225);

                entity.Property(e => e.Link3)
                    .HasColumnName("link3")
                    .HasMaxLength(225);

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasColumnName("link_url")
                    .HasMaxLength(225);

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Range).HasColumnName("range");

                entity.Property(e => e.Root).HasColumnName("root");

                entity.Property(e => e.Words).HasColumnName("words");
            });

            modelBuilder.Entity<Webv02>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("webv02");

                entity.Property(e => e.BuyKind1)
                    .HasColumnName("buy_kind1")
                    .HasMaxLength(255);

                entity.Property(e => e.BuyKind2)
                    .HasColumnName("buy_kind2")
                    .HasMaxLength(255);

                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Keyword).HasColumnName("keyword");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(401);

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("link_url")
                    .HasMaxLength(255);

                entity.Property(e => e.MailCount).HasColumnName("mail_count");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Person)
                    .HasColumnName("person")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic5)
                    .HasColumnName("pic5")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Price2).HasColumnName("price2");

                entity.Property(e => e.Price3).HasColumnName("price3");

                entity.Property(e => e.ProBonus).HasColumnName("pro_bonus");

                entity.Property(e => e.ProCount).HasColumnName("pro_count");

                entity.Property(e => e.ProKind)
                    .HasColumnName("pro_kind")
                    .HasMaxLength(20);

                entity.Property(e => e.ProKind2)
                    .HasColumnName("pro_kind2")
                    .HasMaxLength(10);

                entity.Property(e => e.ProKind3)
                    .HasColumnName("pro_kind3")
                    .HasMaxLength(10);

                entity.Property(e => e.ProLang)
                    .HasColumnName("pro_lang")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProNum)
                    .HasColumnName("pro_num")
                    .HasMaxLength(50);

                entity.Property(e => e.ProOther)
                    .HasColumnName("pro_other")
                    .HasMaxLength(255);

                entity.Property(e => e.ProQty)
                    .HasColumnName("pro_qty")
                    .HasMaxLength(8);

                entity.Property(e => e.ProQtyChk).HasColumnName("pro_qty_chk");

                entity.Property(e => e.ProSell)
                    .HasColumnName("pro_sell")
                    .HasMaxLength(10);

                entity.Property(e => e.Range).HasColumnName("range");

                entity.Property(e => e.Selltime1)
                    .HasColumnName("selltime1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selltime2)
                    .HasColumnName("selltime2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specification)
                    .HasColumnName("specification")
                    .HasMaxLength(255);

                entity.Property(e => e.Words).HasColumnName("words");

                entity.Property(e => e.Words2).HasColumnName("words2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
