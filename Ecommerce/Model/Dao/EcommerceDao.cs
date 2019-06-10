using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class EcommerceDao
    {
        EcommerceDbContext db = null;
        public EcommerceDao()
        {
            db = new EcommerceDbContext();
        }
        public List<Slide> ListSlide()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public List<ContentCategory> ListAllContent()
        {
            return db.ContentCategories.Where(x => x.Status == true).ToList();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
        public List<Category> ListAllCategory()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.MenuType_ID == groupId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        
        public List<Footer> ListFooterByGroupId(int groupId)
        {
            return db.Footers.Where(x => x.FooterType_ID == groupId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListSaleProduct(int top)
        {
            return db.Products.OrderBy(x => x.PromotionPrice).Take(top).ToList();
        }
        public List<Brand> ListBrand(int brand)
        {
            return db.Brands.OrderBy(x => x.CreateDate).Take(brand).ToList();
        }
        public List<Product> ListRelatedProducts(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.Category_ID == product.Category_ID).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        
        

    }
}
