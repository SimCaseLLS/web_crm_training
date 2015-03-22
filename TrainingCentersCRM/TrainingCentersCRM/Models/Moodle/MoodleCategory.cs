using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models.Moodle
{
    public class MoodleCategory
    {
        public List<MoodleCategory> Categories { get; set; }

        public List<MoodleCourse> Courses { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string IdName { get; set; }

        public MoodleCategory()
        {
        }

        public MoodleCategory(SingleResult r, SingleResult[] sRes, HttpContextBase context)
        {
            Id = r["id"];
            IdName = r["idnumber"];
            Name = r["name"];
            Categories = BuildCategories(r, sRes, context);
            if (Convert.ToInt32(r["coursecount"]) > 0)
                Courses = BuildCourses(r, context);

        }

        public static List<MoodleCourse> BuildCourses(SingleResult r, HttpContextBase context)
        {
            List<MoodleCourse> res = new List<MoodleCourse>();
            if (Convert.ToInt32(r["coursecount"]) > 0)
            {
                // Добавляем курсы из moodle
                var courses = MoodleRequestManager.InvokeMethod("core_course_get_courses", context).MultiValue.Where(a => a["categoryid"] == r["id"]);
                foreach (var c in courses)
                    res.Add(new MoodleCourse
                    {
                        Id = c["id"],
                        Name = c["fullname"],
                        ShortName = c["shortname"],
                        Description = c["summary"]
                    });
                return res;
            }
            return null;
        }

        public static List<MoodleCategory> BuildCategories(SingleResult root, SingleResult[] sRes, HttpContextBase context)
        {
            List<MoodleCategory> res = new List<MoodleCategory>();
            var childs = sRes.Where(a => a["parent"].Equals(root["id"]));
            foreach (var r in childs)
                res.Add(new MoodleCategory(r, sRes, context));
            return res;
        }

    }
}