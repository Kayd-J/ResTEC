package com.example.app

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.administrar_carrito.*


class AdministrarCarrito: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.administrar_carrito)

        //Botón de acceso a la ventana de Generar Pedido
        btnconfirmar.setOnClickListener {
            startActivity(Intent(this, GenerarPedido::class.java))
        }
    }
}