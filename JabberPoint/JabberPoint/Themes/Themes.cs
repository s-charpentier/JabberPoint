﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JabberPoint.Domain.Themes
{
    public class Themes
    {
        private List<Theme> _internalList;

        public Theme this[string name]=>_internalList.First(x=>x.Name == name);
    }
}
