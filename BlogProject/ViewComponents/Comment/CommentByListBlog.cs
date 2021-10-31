using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Comment
{
    public class CommentByListBlog:ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList(2);
            return View(values);
        }

    }
}
