#pragma once
#include <SDL.h>
#include <string>

using namespace std;

class Game
{
public:
	Game();
	void LoadContent(SDL_Renderer* renderer);
	void Update(float delta, const Uint8* keyboard);
	void Draw(SDL_Renderer* renderer);
	void Destroy();
	

private:
	void LoadTexture(SDL_Texture** texture, SDL_Renderer* renderer, string path);
	SDL_Texture* m_background;
	SDL_Texture* m_ship;
	SDL_Texture* m_env;

	SDL_Rect m_dest;
	SDL_Rect m_source;

	


	int coin = 113;
	int block = 133;
	int row = 16;
	int x = 4;
	int y = 0;

	int gridWidth = 10;
	int gridHeight = 20;
	int tileWidth = 32;
	int tileHeight = 32;

	int m_grille[20][10] = {
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
	    {block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
		{block, block, block, block, block, block ,block ,block ,block ,block},
	};
};