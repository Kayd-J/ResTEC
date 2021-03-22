package com.example.app

import android.content.Intent
import android.os.Bundle
import android.os.Handler
import androidx.appcompat.app.AppCompatActivity

class Inicio: AppCompatActivity() {

    lateinit var  handler: Handler

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.inicio)

        handler = Handler()
        handler.postDelayed({

            val intent = Intent(this , MainActivity::class.java)
            startActivity(intent)
            finish()
        }, 3000)
    }

}