﻿namespace Favolog.Service.Models
{
    public class UserFeed: Entity
    {
        public int CatalogId { get; set; }               

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImage { get; set; }

        public string CatalogName { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public string Url { get; set; }

        public string Comments { get; set; }

        public int AudienceType { get; set; }

    }
}
