package com.example.app

import com.google.gson.annotations.SerializedName

data class RespuestaMenu (
    @SerializedName("id") var identificador: String,
    @SerializedName("platillo") var platillo_nombre: String,
    @SerializedName("descripcion") var des: String,
    @SerializedName("tiempo") var tiempo_prep: String
)
