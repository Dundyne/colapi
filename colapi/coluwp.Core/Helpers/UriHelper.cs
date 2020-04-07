using System;
using System.Collections.Generic;
using System.Text;

namespace coluwp.Core.Helpers
{
    public static class UriHelper
    {
        //Student Uri
        public static Uri studentUri = new Uri("http://localhost:59622/api/Students/");

        //Course Uri
        public static Uri courseUri = new Uri("http://localhost:59622/api/Courses");

        //Enrollment Uri
        public static Uri enrollmentUri = new Uri("http://localhost:59622/api/Enrollments");
    }
}
