#![no_std]

use soroban_sdk::{contractimpl, symbol_short, Env, Symbol, Vec, Address, storage::Map};

#[derive(Clone)]
pub struct PlayerNFT {
    pub id: Symbol,
    pub name: Symbol,
    pub image_url: Symbol,
    pub price: u64,
    pub owner: Address,
}

#[contract]
pub struct NftMarketplace {
    nft_owner: Map<Symbol, Address>,
    nft_price: Map<Symbol, u64>,
}

#[contractimpl]
impl NftMarketplace {
    pub fn new(env: Env) -> Self {
        Self {
            nft_owner: Map::new(env),
            nft_price: Map::new(env),
        }
    }

    pub fn mint_nft(env: Env, id: Symbol, name: Symbol, image_url: Symbol, price: u64) {
        let caller = env.caller();
        // Ensure the NFT ID is unique
        assert!(
            !env.storage().has(&id),
            "NFT with this ID already exists."
        );
        // Create and store the NFT
        let nft = PlayerNFT {
            id: id.clone(),
            name,
            image_url,
            price,
            owner: caller.clone(),
        };
        env.storage().set(&id, nft.clone());
        env.storage().set(&nft.owner, id.clone()); // Optional: Map owner to NFT
    }

    pub fn set_price(env: Env, id: Symbol, new_price: u64) {
        let caller = env.caller();
        let mut nft: PlayerNFT = env.storage().get(&id).expect("NFT does not exist.");
        assert!(
            nft.owner == caller,
            "Only the owner can set the price."
        );
        nft.price = new_price;
        env.storage().set(&id, nft);
    }

    pub fn buy_nft(env: Env, id: Symbol) {
        let buyer = env.caller();
        let nft: PlayerNFT = env.storage().get(&id).expect("NFT does not exist.");
        let price = nft.price;

        // Ensure buyer has enough XLM (implementation depends on SDK capabilities)
        // Transfer XLM from buyer to seller
        env.transfer(nft.owner.clone(), price).expect("Failed to transfer XLM.");

        // Update ownership
        let updated_nft = PlayerNFT {
            owner: buyer.clone(),
            ..nft
        };
        env.storage().set(&id, updated_nft);
    }

    pub fn get_nft(env: Env, id: Symbol) -> PlayerNFT {
        env.storage().get(&id).expect("NFT does not exist.")
    }

    pub fn list_nfts(env: Env) -> Vec<PlayerNFT> {
        let mut nfts = Vec::new();
        let keys = env.storage().keys();
        for key in keys.iter() {
            if let Ok(nft) = env.storage().get(key) {
                nfts.push(nft);
            }
        }
        nfts
    }
}