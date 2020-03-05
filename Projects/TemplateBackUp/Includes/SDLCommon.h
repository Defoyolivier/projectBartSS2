#pragma once
#include <Game.h>
#include <string>

using namespace std;

bool InitializeSDL(Game* game, string title, const int width, const int height);
bool InitWindow(string title, const int width, const int height);
bool InitRenderer();
void ShutDownSDL(Game* game);
void RunSDLGame(Game* game);
void ManageInput();
void DrawSDLGame(Game* game);