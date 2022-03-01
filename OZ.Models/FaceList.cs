using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class FaceList
    {
        [Key]
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public int FacePositionXc { get; set; }
        public int FacePositionYc { get; set; }
        public int FacePositionW { get; set; }
        public float FacePositionAngle { get; set; }
        public int Eye1X { get; set; }
        public int Eye1Y { get; set; }
        public int Eye2X { get; set; }
        public int Eye2Y { get; set; }
        public byte[] Template { get; set; }
        public byte[] Image { get; set; }
        public byte[] FaceImage { get; set; }
    }
}
