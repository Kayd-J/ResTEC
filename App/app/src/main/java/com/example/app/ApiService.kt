package com.example.app

import okhttp3.Response
import retrofit2.http.GET
import retrofit2.http.Url

interface ApiService {
        @GET
        suspend fun TomarDatos(@Url url:String):retrofit2.Response<RespuestaMenu>
}