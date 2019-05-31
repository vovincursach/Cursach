﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КП.ResponseModels
{
    public class Image
    {
        public Image(int id, string filename, string title, byte[] data)
        {
            Id = id;
            FileName = filename;
            Title = title;
            Data = data;
        }
        public int Id { get; private set; }
        public string FileName { get; private set; }
        public string Title { get; private set; }
        public byte[] Data { get; private set; }
    }
}
