﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using Udemy.OgrenciTakip.Bll.Base;
using Udemy.OgrenciTakip.Common.Enums;
using Udemy.OgrenciTakip.Data.Contexts;
using Udemy.OgrenciTakip.Model.Dto;
using Udemy.OgrenciTakip.Model.Entities;
using Udemy.OgrenciTakip.Model.Entities.Base;
using System.Linq;

namespace Udemy.OgrenciTakip.Bll.General
{
    public class OkulBll : BaseBll<Okul, OgrenciTakipContext>
    {
        // BaseBll class'ında iki adet constructor oldugu için  burada da iki adet oluşturduk
        public OkulBll() { }

        public OkulBll(Control ctrl) : base(ctrl) { }

        // Aşağıda kullanmak için data transfer objeleri oluşturacağız ve bunlarda Model katmanında olacak.
        public BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.IlAdi, // okuldan il'e ulaştık il'den de iladi na ulaştık
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum,
            });
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlAdi = x.Il.IlAdi,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();  // database yansıması için IQueryable'ı List,e çevirdik
            // Tolist işlemi; entity yapılarımızı database'e yansıtacak
            // henüz veriler çekilmeden database de sıralama yap ve dataları listele 
            // demiş olduk. Base class da yapsaydık sıralamadan verileri çekip ekstra burada sıralama 
            // işlemi yapacaktık.
        }

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.Kod == entity.Kod);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, KartTuru.Okul);
        }
    }
}
