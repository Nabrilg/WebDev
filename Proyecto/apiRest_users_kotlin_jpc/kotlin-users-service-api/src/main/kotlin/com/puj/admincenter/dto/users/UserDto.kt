package com.puj.admincenter.dto.users

import com.puj.admincenter.domain.users.User

data class UserDto(
    val email: String,
    val id: Int,
    val name: String,
    val password:String,
    var username: String
) {
    companion object {
        fun convert(user: User): UserDto {
            val dto = UserDto(
                email= user.email,
                id = user.id,
                name = user.name,
                password= user.password,
                username = user.username
            )
            return dto
        }
    }
}