#include "SDLCommon.h"
#include <SDL.h>
#include <game.h>
#include <string>

using namespace std;

// SDL Window pointer:
SDL_Window* g_window = nullptr;

// SDL Rendering states:
SDL_Renderer* g_renderer = nullptr;

bool g_isRunning = false;

bool InitializeSDL(Game* game, string title,const int width,const int height)
{
	if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
	{
		SDL_Log("Error: %s\n", SDL_GetError());
		return false;
	}

	if (!InitWindow(title, width, height))
	{
		SDL_Log("Error: %s\n", SDL_GetError());
		return false;
	}

	if (!InitRenderer())
	{
		SDL_Log("Error: %s\n", SDL_GetError());
		return false;
	}

	game->LoadContent(g_renderer);

	return true;
}

bool InitWindow(string title, const int width, const int height)
{
	const Uint32 flags = SDL_WINDOW_UTILITY;
	const int pos = SDL_WINDOWPOS_CENTERED;
	g_window = SDL_CreateWindow(title.c_str(), pos, pos, width, height, flags);

	if (g_window == nullptr)
	{
		SDL_Log("Error: %s\n", SDL_GetError());
		return false;
	}

	return true;
}

bool InitRenderer()
{
	const Uint32 flag = SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC;
	g_renderer = SDL_CreateRenderer(g_window, -1, flag);
	if (g_renderer == nullptr)
	{
		SDL_Log("Error: %s\n", SDL_GetError());
		return false;
	}
	return true;
}

void ShutDownSDL(Game* game)
{
	game->Destroy();

	SDL_DestroyRenderer(g_renderer);
	SDL_DestroyWindow(g_window);
	SDL_Quit();
}

void RunSDLGame(Game * game)
{
	g_isRunning = true;
	while (g_isRunning)
	{
		ManageInput();
		game->Update(0.0f);
		DrawSDLGame(game);
	}
}

void ManageInput()
{
	SDL_Event event;
	while (SDL_PollEvent(&event) > 0)
	{
		switch (event.type)
		{
		case SDL_QUIT:
			g_isRunning = false;
			break;
		}
	}
}

void DrawSDLGame(Game * game)
{
	SDL_SetRenderDrawColor(g_renderer, 115, 130, 250, 255);
	SDL_RenderClear(g_renderer);
	game->Draw(g_renderer);
	SDL_RenderPresent(g_renderer);
}
