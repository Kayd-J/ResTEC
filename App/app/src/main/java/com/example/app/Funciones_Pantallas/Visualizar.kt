package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.os.Handler
import androidx.appcompat.app.AppCompatActivity
import com.example.app.Especiales.Cargar
import com.example.app.R
import kotlinx.android.synthetic.main.visualizar.*

class Visualizar: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.visualizar)

        //val intent = getIntent()
        //val tiempo = intent.getStringExtra("preparacion")

        val cargar = Cargar(this)
        cargar.ComenzarCarga()
        val handler = Handler()

        handler.postDelayed(object :Runnable {
            override fun run() {
                cargar.isDissmis()
            }
        }, 5000)

        btnconcretar.setOnClickListener {
            startActivity(Intent(this, Feedback::class.java))
        }
    }
}