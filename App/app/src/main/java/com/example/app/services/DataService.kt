package com.example.app.services

import com.example.app.Platillo
import retrofit2.Call
import retrofit2.http.GET

interface DataService {

    @GET("dishes")
    fun getDishesList(): Call<List<Platillo>>
}