﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Crowd_knowledge_contribution.Models
{
    public class Article
    {
        [Key, Column(Order = 1)] 
        public int ArticleId { get; set; }
        [Key, Column(Order = 2)] 
        public int VersionId { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime LastModified { get; set; }
    }
}