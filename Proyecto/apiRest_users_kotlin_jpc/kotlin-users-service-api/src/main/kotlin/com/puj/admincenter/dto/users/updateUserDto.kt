package com.puj.admincenter.dto.users

data class UpdateUserDto(
    val id: Int,
    val email: String,
    val name: String,
    val username: String,
    val password: String
)