using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMap_Entities
{
    public class DungeonMapContext : DbContext
    {
        public DungeonMapContext(DbContextOptions<DungeonMapContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bailey = new User { Id = 1, UserName = "critical.bailure", FirstName = "Bailey", LastName = "Stoddard", Email = "fakeEmailNumber1@gmail.com", CreatedBy = 1, PasswordHash = "change", UpdatedBy = 1 };
            var dustin = new User { Id = 2, UserName = "dpatrick", FirstName = "Dustin", LastName = "Patrick", Email = "dustin.patrick@fakeEmail.io", CreatedBy = 1, PasswordHash = "change", UpdatedBy = 1 };
            var kaylin = new User { Id = 3, UserName = "xXxLiaxXx", FirstName = "Kaylin", LastName = "Jones", Email = "something@gmail.com", CreatedBy = 1, PasswordHash = "change", UpdatedBy = 1 };
            var russell = new User { Id = 4, UserName = "_dreyfus", FirstName = "Russell", LastName = "Patrick", Email = "something_else@gmail.com", CreatedBy = 1, PasswordHash = "change", UpdatedBy = 1 };

            var game = new Game { Id = 1, Name = "Out Of The Abyss", GameType = DungeonMap_Common.Enums.GameType.DungeonsAndDragons5e, CreatedBy = 1, UpdatedBy = 1, UpdatedDate = DateTime.UtcNow };

            modelBuilder.Entity<User>()
                .HasOne(user => user.Settings)
                .WithOne(settings => settings.User)
                .HasForeignKey<UserSettings>(x => x.Id);
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Characters)
                .WithOne(x => x.User);
            modelBuilder.Entity<User>()
                .HasData(bailey, dustin, kaylin, russell);

            modelBuilder.Entity<UserFriend>()
                .HasKey(k => new { k.FriendId, k.UserId });
            modelBuilder.Entity<UserFriend>()
                .HasOne(friend => friend.User)
                .WithMany(user => user.UserFriends)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>()
                .HasOne(friend => friend.Friend)
                .WithMany(user => user.FriendUsers)
                .HasForeignKey(k => k.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSettings>()
                .HasOne(settings => settings.User)
                .WithOne(user => user.Settings)
                .HasForeignKey<User>(x => x.Id);
            modelBuilder.Entity<UserSettings>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<UserSettings>()
                .Property(x => x.SubscriptionType)
                    .HasConversion<short>();
            modelBuilder.Entity<UserSettings>()
                .HasData(
                    new UserSettings { Id = 1, PreferredCharacterName = "Letherna: The Silencer", Biography = "I silence things", PhoneNumber = "5554443210", SkypeHandle = "critical.bailure", SubscriptionType = DungeonMap_Common.Enums.SubscriptionType.Premium, CreatedBy = 1, UpdatedBy = 1 },
                    new UserSettings { Id = 2, PreferredCharacterName = "God", Biography = "Malevolent Dungeonmaster", PhoneNumber = "5554441234", SkypeHandle = "dustin.patrick", SubscriptionType = DungeonMap_Common.Enums.SubscriptionType.Premium, CreatedBy = 1, UpdatedBy = 1 },
                    new UserSettings { Id = 3, PreferredCharacterName = "Lia", Biography = "New to the game. Also you just lost the game", PhoneNumber = "5554443210", SkypeHandle = "jk_its_kj", SubscriptionType = DungeonMap_Common.Enums.SubscriptionType.Premium, CreatedBy = 1, UpdatedBy = 1 },
                    new UserSettings { Id = 4, PreferredCharacterName = "Dreyfus", Biography = "I'm just here so I don't get fined", PhoneNumber = "5554443210", SkypeHandle = "something_creative", SubscriptionType = DungeonMap_Common.Enums.SubscriptionType.Free, CreatedBy = 1, UpdatedBy = 1 }
                );


            modelBuilder.Entity<Game>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Game>()
                .Property(x => x.GameType)
                    .HasConversion<short>();
            modelBuilder.Entity<Game>()
                .HasMany(x => x.Characters)
                .WithOne(x => x.Game);
            modelBuilder.Entity<Game>()
                .HasData(game);

            modelBuilder.Entity<Character>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Character>()
                .Property(x => x.RoleType)
                    .HasConversion<short>();
            modelBuilder.Entity<Character>()
                .HasOne(x => x.User)
                .WithMany(x => x.Characters);
            modelBuilder.Entity<Character>()
                .HasData(
                    new Character { Id = 1, RoleType = DungeonMap_Common.Enums.RoleType.Player, UserId = 1, CharacterName = "Letherna", GameId = 1, CreatedBy = 1, UpdatedBy = 1, },
                    new Character { Id = 2, RoleType = DungeonMap_Common.Enums.RoleType.Player, UserId = 2, CharacterName = "Lia", GameId = 1, CreatedBy = 1, UpdatedBy = 1, },
                    new Character { Id = 3, RoleType = DungeonMap_Common.Enums.RoleType.Player, UserId = 3, CharacterName = "Dungeon Master", GameId = 1, CreatedBy = 1, UpdatedBy = 1, },
                    new Character { Id = 4, RoleType = DungeonMap_Common.Enums.RoleType.Player, UserId = 4, CharacterName = "Dreyfus", GameId = 1, CreatedBy = 1, UpdatedBy = 1, }
                );
        }
    }
}
