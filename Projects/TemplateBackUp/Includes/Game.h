#pragma once
#include <SDL.h>
class Game
{
public:
	void LoadContent(SDL_Renderer* renderer);
	void Update(float delta);
	void Draw(SDL_Renderer* renderer);
	void Destroy();

private:

};