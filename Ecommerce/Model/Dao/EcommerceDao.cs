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
        public List<Content_Category> ListAllContent()
        {
            return db.Content_Category.Where(x => x.Status == true).ToList();
        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
        public List<Category> ListAllCategory()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public List<SubCategory> ListAllSubCategory()
        {
            return db.SubCategories.Where(x => x.Status == true).ToList();
        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId).ToList();
        }
    }
}
