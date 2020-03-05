#define WIN32_LEAN_AND_MEAN
#define VC_EXTRALEAN

#include <Game.h>
#include <SDLCommon.h>
#include <Windows.h>

int WINAPI WinMain(HINSTANCE hinst, HINSTANCE hprev, LPSTR str, int cmd)
{
	Game game;

	if (InitializeSDL(&game, "My Game", 850, 650))
	{
		RunSDLGame(&game);
		ShutDownSDL(&game);
	}
	return 0;
}