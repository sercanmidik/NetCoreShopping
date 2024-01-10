using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BannerDtos
{
    public class ResultBannerProductDto
    {
        public int ProductId { get; set; }
        public string BannerTitleOne { get; set; }
        public string BannerTitleTwo { get; set; }
        public string BannerImageUrl { get; set; }
        public string BannerContent { get; set; }
    }
}
