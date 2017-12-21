﻿using System;
using System.Collections.Generic;
using ICT13580574EndB.Models;
using Xamarin.Forms;

namespace ICT13580574EndB
{
    public partial class ProductNewPage : ContentPage
    {
        Product car;
        public ProductNewPage(Product car = null)
        {
            InitializeComponent();
            this.car = car;

            addCar.Clicked += AddCar_Clicked;
            cancelCar.Clicked += CancelCar_Clicked;


            cateoryPicker.Items.Add("สองประตู");
            cateoryPicker.Items.Add("สี่ประตู");

            brandPicker.Items.Add("Yamaha");
            brandPicker.Items.Add("Honda");
            brandPicker.Items.Add("Toyota");

            colorPicker.Items.Add("สีแดง");
            colorPicker.Items.Add("สีดำ");
            colorPicker.Items.Add("สีขาว");

            provincePicker.Items.Add("กรุงเทพ");
            provincePicker.Items.Add("ชลบุรี");
            provincePicker.Items.Add("ฉะเชิงเทรา");


            mileSlider.ValueChanged += MileSlider_ValueChanged;
            yearStepper.ValueChanged += YearStepper_ValueChanged;

            if (car != null)
            {
                titleLabel.Text = "edit car";
                cateoryPicker.SelectedItem = car.CateoryCar;
                brandPicker.SelectedItem = car.Brand;
                colorPicker.SelectedItem = car.Color;
                provincePicker.SelectedItem = car.Province;
                grandEntry.Text = car.Grand;

                yearLabel.Text = car.Year;
                priceEntry.Text = car.Price.ToString();
                mileLabel.Text = car.Km.ToString();
                detailEditor.Text = car.Description;
                phoneEntry.Text = car.Numberphone;



            }


        }

        async void AddCar_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {


                if (car == null)
                {
                    car = new Product();
                    car.CateoryCar = cateoryPicker.SelectedItem.ToString();
                    car.Brand = brandPicker.SelectedItem.ToString();
                    car.Color = colorPicker.SelectedItem.ToString();
                    car.Province = provincePicker.SelectedItem.ToString();
                    car.Grand = grandEntry.Text;

                    car.Price = decimal.Parse(priceEntry.Text);
                    car.Year = yearLabel.Text;
                    car.Km = decimal.Parse(mileLabel.Text);
                    car.Description = detailEditor.Text;
                    car.Numberphone = phoneEntry.Text;


                    var id = App.DbHelper.AddProduct(car);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสรถของท่าน #" + id, "ตกลง");
                }
                else
                {


                    car.CateoryCar = cateoryPicker.SelectedItem.ToString();
                    car.Brand = brandPicker.SelectedItem.ToString();
                    car.Color = colorPicker.SelectedItem.ToString();
                    car.Province = provincePicker.SelectedItem.ToString();
                    car.Grand = grandEntry.Text;

                    car.Price = decimal.Parse(priceEntry.Text);
                    car.Year = yearLabel.Text;
                    car.Km = decimal.Parse(mileLabel.Text);
                    car.Description = detailEditor.Text;
                    car.Numberphone = phoneEntry.Text;
                    var id = App.DbHelper.UpdateProduct(car);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย", "ตกลง");

                }

                await Navigation.PopModalAsync();



            }


        }

        void CancelCar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }void MileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            mileLabel.Text = e.NewValue.ToString();
        }

        void YearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            yearLabel.Text = e.NewValue.ToString();
        }
    }
}