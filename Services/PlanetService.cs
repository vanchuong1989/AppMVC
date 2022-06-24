﻿using AppMVC.Models;
using System.Collections.Generic;

namespace AppMVC.Services
//AppMVC.Services.PlanetService
{
    public class PlanetService : List<PlanetModel>
    {
        public PlanetService()
        {
            Add(new PlanetModel() {
              Id=1,
              Name= "Mercury",
              VnName= "Sao Thủy",
              Content= "Sao Thủy (cách Mặt Trời khoảng 0,4 AU) là hành tinh gần Mặt Trời nhất và là hành tinh nhỏ nhất trong Hệ Mặt Trời (0,055 lần khối lượng Trái Đất). Sao Thủy không có vệ tinh tự nhiên, và nó chỉ có các đặc trưng địa chất bên cạnh các hố va chạm đó là các sườn và vách núi, có lẽ được hình thành trong giai đoạn co lại đầu tiên trong lịch sử của nó. Sao Thủy hầu như không có khí quyển do các nguyên tử trong bầu khí quyển của nó đã bị gió Mặt Trời thổi bay ra ngoài không gian. Hành tinh này có lõi sắt tương đối lớn và lớp phủ khá mỏng mà vẫn chưa được các nhà thiên văn giải thích được một cách đầy đủ. Có giả thuyết cho rằng lớp phủ bên ngoài đã bị tước đi sau 1 vụ va chạm khổng lồ, và quá trình bồi tụ vật chất của Sao Thủy bị ngăn chặn bởi năng lượng của Mặt Trời trẻ."
            });

            Add(new PlanetModel()
            {
                Id = 2,
                Name = "Venus",
                VnName = "Sao Kim",
                Content = "Sao Kim (cách Mặt Trời khoảng 0,7 AU) có kích cỡ khá gần với kích thước Trái Đất (với khối lượng bằng 0,815 lần khối lượng Trái Đất) và đặc điểm cấu tạo giống Trái Đất, nó có 1 lớp phủ silicat dày bao quanh 1 lõi sắt. Sao Kim có 1 bầu khí quyển dày và có những chứng cứ cho thấy hành tinh này còn sự hoạt động của địa chất bên trong nó. Tuy nhiên, Sao Kim khô hơn Trái Đất rất nhiều và mật độ bầu khí quyển của nó gấp 90 lần mật độ bầu khí quyển của Trái Đất. Sao Kim không có vệ tinh tự nhiên. Nó là hành tinh nóng nhất trong hệ Mặt Trời với nhiệt độ của bầu khí quyển trên 400 °C, nguyên nhân chủ yếu là do hiệu ứng nhà kính của bầu khí quyển. Không có dấu hiệu cụ thể về hoạt động địa chất gần đây được phát hiện trên Sao Kim (1 lý do là nó có bầu khí quyển quá dày), mặt"
            });

            Add(new PlanetModel()
            {
                Id = 3,
                Name = "Earth",
                VnName = "Trái Đất",
                Content = "Trái Đất (cách Mặt Trời 1 AU) là hành tinh lớn nhất và có mật độ lớn nhất trong số các hành tinh vòng trong, cũng là hành tinh duy nhất mà chúng ta biết còn có các hoạt động địa chất gần đây, và là hành tinh duy nhất trong vũ trụ được biết đến là nơi có sự sống tồn tại. Trái Đất cũng là hành tinh đá duy nhất có thủy quyển lỏng, và cũng là hành tinh duy nhất nơi quá trình kiến tạo mảng đã được quan sát. Bầu khí quyển của Trái Đất cũng khác căn bản so với các hành tinh khác với thành phần phân tử oxy tự do thiết yếu c"
            });
        }
    }
}
