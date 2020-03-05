#include "Game.h"
#include <stdlib.h>
#include <cstdlib>
#include <time.h>
#include <stdio.h> 
#include <SDL_image.h>
Game::Game() : m_background(nullptr), m_ship(nullptr), m_env(nullptr),
m_dest({ 0, 0, 32, 32 }), m_source({256, 160, 32, 32})
{
}

void Game::LoadContent(SDL_Renderer* renderer)
{
	LoadTexture(&m_background, renderer, "Assets/bg.png");
	LoadTexture(&m_ship, renderer, "Assets/ship.png");
	LoadTexture(&m_env, renderer, "Assets/env.png");
}

void Game::Update(float delta, const Uint8* keyboard)
{
	if (keyboard[SDL_SCANCODE_SPACE]) 
	{
		m_grille[y][x] = block;
		y++;

		if (y > gridHeight) {
			y = 0;
		}
		m_grille[y][x] = coin;

	}


}

void Game::Draw(SDL_Renderer* renderer)
{

	for (int y = 0; y < gridHeight; y++) 
	{
		for (int x = 0; x < gridWidth; x++)
		{
			m_dest.x = x * tileWidth;
			m_dest.y = y * tileHeight;

			

			int I = m_grille[y][x];
			int Y = I / row;
			int X = I % row;

			m_source.x = X * tileWidth;
			m_source.y = Y * tileHeight;

			SDL_RenderCopyEx(renderer, m_env, &m_source, &m_dest, 0.0, nullptr, SDL_FLIP_NONE);
		}
		
	}
}

void Game::Destroy()
{
}

void Game::LoadTexture(SDL_Texture** texture, SDL_Renderer * renderer, string path)
{
	*texture = IMG_LoadTexture(renderer, path.c_str());

	if (*texture == nullptr)
	{
		SDL_Log("Error loading texture %s", path.c_str());
	}
}
